using Clinica.AtencionPaciente.Domain.Entities;
using Clinica.AtencionPaciente.Domain.Factories;
using Clinica.AtencionPaciente.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Application.ClinicServices.CommandClinicCreate
{
    public class ClinicCreateHandler : IRequestHandler<ClinicCreate, ClinicCreateDTO>
    {
        private readonly IRepository repository;

        private readonly IFactory factory;

        private readonly IAutoMapping autoMapping;

        public ClinicCreateHandler(IRepository repository, IFactory factory, IAutoMapping autoMapping)
        {
            this.autoMapping = autoMapping;
            this.factory = factory;
            this.repository = repository;
        }

        public async Task<ClinicCreateDTO> Handle(ClinicCreate request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("la peticion para registrar la consulta clinica es nula.");

            //crear especialista
            var idEspecialista = await CrearEspecialista(request.NombreEspecialista, cancellationToken);

            //crear
            var cClinica =(ConsultaClinica) this.factory.CreateConsultaClinica(
                cantidadPacientes: 0, 
                tipoConsulta: request.TipoConsulta,
                estado: request.Estado,
                especialistaId: idEspecialista
                );

            //retornar, guardar y mapear
            cClinica = await this.repository.Save<ConsultaClinica>(cClinica, cancellationToken);
            return this.autoMapping.Map<ConsultaClinica, ClinicCreateDTO>(cClinica);
        }

        private async Task<string> CrearEspecialista(string nombre, CancellationToken cancellationToken)
        {
            //fabricar
            var espesialista = (Especialista)this.factory.CreateEspecialista(nombre);

            //guardar
            espesialista = await this.repository.Save<Especialista>(espesialista, cancellationToken);

            return espesialista.Id;
        }
    }
}
