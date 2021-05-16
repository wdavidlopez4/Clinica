using Clinica.AtencionPaciente.Domain.Entities;
using Clinica.AtencionPaciente.Domain.Factories;
using Clinica.AtencionPaciente.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Application.hospitalService.CommandHospitalCreateOne
{
    public class HospitalCreateOneHandler : IRequestHandler<HospitalCreateOne, HospitalCreateOneDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IFactory factory;

        public HospitalCreateOneHandler(IRepository repository, IAutoMapping autoMapping, IFactory factory)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
            this.factory = factory;
        }

        public async Task<HospitalCreateOneDTO> Handle(HospitalCreateOne request, CancellationToken cancellationToken)
        {
            //validar
            if (request == null)
                throw new ArgumentNullException("la peticion para registrar el ninno es nula");

            //falta con verificar si existe un hospital para determinar si se crea o se retorna
            var hospital = await this.repository.GetFirst<Hospital>(cancellationToken);

            if(hospital != null)
                return this.autoMapping.Map<Hospital, HospitalCreateOneDTO>(hospital);

            else
            {
                hospital = (Hospital)this.factory.CreateHospital();
                hospital = await this.repository.Save<Hospital>(hospital, cancellationToken);
                return this.autoMapping.Map<Hospital, HospitalCreateOneDTO>(hospital);
            }
        }
    }
}
