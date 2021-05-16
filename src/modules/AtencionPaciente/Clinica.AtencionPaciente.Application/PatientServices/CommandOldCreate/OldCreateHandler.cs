using Clinica.AtencionPaciente.Application.Execptions;
using Clinica.AtencionPaciente.Domain.Entities;
using Clinica.AtencionPaciente.Domain.Factories;
using Clinica.AtencionPaciente.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Application.PatientServices.CommandOldCreate
{
    public class OldCreateHandler : IRequestHandler<OldCreate, OldCreateDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IFactory factory;

        public OldCreateHandler(IRepository repository, IAutoMapping autoMapping, IFactory factory)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
            this.factory = factory;
        }

        public async Task<OldCreateDTO> Handle(OldCreate request, CancellationToken cancellationToken)
        {
            //validar
            if (request == null)
                throw new ArgumentNullException("la peticion para registrar el ninno es nula");

            else if (this.repository.Exists<Hospital>(x => x.Id == request.HospitalId))
                throw new EntityNullException("aun no se a creado el hospital");

            //calcular
            var prioridad = CalcularPrioridad(request.TieneDieta, request.Edad);
            var riesgo = CalcularRiesgo(request.Edad, prioridad);

            //fabricar
            var anciano =(Anciano) this.factory.CreateAnciano(
                tieneDieta: request.TieneDieta,
                nombre: request.Nombre,
                edad: request.Edad,
                numeroHistoriasClinico: request.NumeroHistoriasClinico,
                hospitalId: request.HospitalId,
                prioridad: prioridad,
                riesgo: riesgo
                );

            //guardar, mapear y retornar
            anciano = await this.repository.Save<Anciano>(anciano, cancellationToken);
            return this.autoMapping.Map<Anciano, OldCreateDTO>(anciano);
        }

        private double CalcularPrioridad(bool tieneDieta, int edad)
        {
            return (tieneDieta == false && edad >= 60 && edad <= 100) ? (edad / 20) + 4 : (edad / 30) + 3;
        }

        private double CalcularRiesgo(int edad, double prioridad)
        {
            return (edad * prioridad) / 100 + 5.3;
        }
    }
}
