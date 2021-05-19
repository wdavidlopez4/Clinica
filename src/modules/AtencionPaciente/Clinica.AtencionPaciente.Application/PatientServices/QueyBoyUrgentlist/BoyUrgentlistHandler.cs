using Clinica.AtencionPaciente.Domain.Entities;
using Clinica.AtencionPaciente.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Application.PatientServices.QueyBoyUrgentlist
{
    public class BoyUrgentlistHandler : IRequestHandler<BoyUrgentlist, List<BoyUrgentlistDTO>>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public BoyUrgentlistHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
        }

        public async Task<List<BoyUrgentlistDTO>> Handle(BoyUrgentlist request, CancellationToken cancellationToken)
        {
            var ninnosMayores = new List<Ninno>();

            //obtener nino para comparacion
            var ninnoComparacion = await this.repository.Get<Ninno>(
                x => x.NumeroHistoriasClinico == request.NumeroHistoriasClinico,
                cancellationToken);

            //ninnos urgentes
            var ninnos = await this.repository.GetAll<Ninno>(
                x => x.Prioridad > 4, 
                x => x.Prioridad, 
                cancellationToken);

            foreach (var ninno in ninnos)
            {
                if(ninno.Prioridad > ninnoComparacion.Prioridad)
                {
                    ninnosMayores.Add(ninno);
                }
            }

            return this.autoMapping.Map<List<Ninno>, List<BoyUrgentlistDTO>> (ninnosMayores);
        }
    }
}
