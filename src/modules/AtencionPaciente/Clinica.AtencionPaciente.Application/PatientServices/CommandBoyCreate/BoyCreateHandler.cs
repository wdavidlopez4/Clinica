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

namespace Clinica.AtencionPaciente.Application.PatientServices.CommandBoyCreate
{
    public class BoyCreateHandler : IRequestHandler<BoyCreate, BoyCreateDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IFactory factory;

        public BoyCreateHandler(IRepository repository, IAutoMapping autoMapping, IFactory factory)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
            this.factory = factory;
        }

        public async Task<BoyCreateDTO> Handle(BoyCreate request, CancellationToken cancellationToken)
        {
            //validar
            if (request == null)
                throw new ArgumentNullException("la peticion para registrar el ninno es nula");

            //calcular
            var prioridad = CalcularPrioridad(request.RelacionPesoEstatura, request.Edad);
            var riesgo = CalcularRiesgo(request.Edad, prioridad);

            //fabricar
            var ninno = (Ninno) this.factory.CreateNinno(
                relacionPesoEstatura: request.RelacionPesoEstatura,
                nombre: request.Nombre,
                edad: request.Edad,
                numeroHistoriasClinico:request.NumeroHistoriasClinico,
                prioridad: prioridad,
                riesgo: riesgo
                );

            //guardar, mapear y retornar
            ninno = await this.repository.Save<Ninno>(ninno, cancellationToken);
            return this.autoMapping.Map<Ninno, BoyCreateDTO>(ninno);
        }

        private double CalcularPrioridad(int pesoEstatuta, int edad)
        {
            double prioridad;

            if (edad >= 1 && edad <= 5)
                prioridad = pesoEstatuta + 3;

            else if(edad >= 6 && edad <= 12)
                prioridad = pesoEstatuta + 2;

            else if (edad >= 13 && edad <= 15)
                prioridad = pesoEstatuta + 1;

            else
                throw new EdadException("la edad ingresada no corresponde a la de un niño");

            return prioridad;
        }

        private double CalcularRiesgo(int edad, double prioridad)
        {
            return (edad * prioridad) / 100;
        }

    }
}
