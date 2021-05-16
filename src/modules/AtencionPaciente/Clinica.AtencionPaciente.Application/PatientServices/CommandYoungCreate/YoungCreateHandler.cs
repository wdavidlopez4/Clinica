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

namespace Clinica.AtencionPaciente.Application.PatientServices.CommandYoungCreate
{
    public class YoungCreateHandler : IRequestHandler<YoungCreate, YoungCreateDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IFactory factory;

        public YoungCreateHandler(IRepository repository, IAutoMapping autoMapping, IFactory factory)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
            this.factory = factory;
        }

        public async Task<YoungCreateDTO> Handle(YoungCreate request, CancellationToken cancellationToken)
        {
            //validar
            if (request == null)
                throw new ArgumentNullException("la peticion para registrar el ninno es nula");

            //asignar hospital
            var hospitalId = await AsignarHospital(cancellationToken);

            //calcular
            var prioridad = CalcularPrioridad(request.EsFumador, request.AnnosFumando);
            var riesgo = CalcularRiesgo(request.Edad, prioridad);

            //fabricar
            var joven =(Joven) this.factory.CreateJoven(
                annosFumando: request.AnnosFumando,
                esFumador:request.EsFumador,
                nombre: request.Nombre,
                edad: request.Edad,
                numeroHistoriasClinico: request.NumeroHistoriasClinico,
                hospitalId: hospitalId,
                prioridad: prioridad,
                riesgo: riesgo
                );

            //guardar, mapear y retornar
            joven = await this.repository.Save<Joven>(joven, cancellationToken);
            return this.autoMapping.Map<Joven, YoungCreateDTO>(joven);
        }

        private double CalcularPrioridad(bool esFumador, int annosFumando)
        {
            return esFumador == true ? (annosFumando / 4) + 2 : 2;

        }

        //mas adelante se puede reducir el codigo de metodos como estos con el una logica compartida
        private double CalcularRiesgo(int edad, double prioridad)
        {
            return (edad * prioridad) / 100;
        }

        //este metodo tambien se puede reutilizar en logica comun mas adelante
        private async Task<string> AsignarHospital(CancellationToken cancellationToken)
        {
            var hospital = (Hospital)this.factory.CreateHospital();
            hospital = await this.repository.Save<Hospital>(hospital, cancellationToken);
            return hospital.Id;
        }
    }
}
