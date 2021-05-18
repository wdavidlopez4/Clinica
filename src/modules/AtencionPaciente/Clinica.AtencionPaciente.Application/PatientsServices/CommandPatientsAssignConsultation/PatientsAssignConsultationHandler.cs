using Clinica.AtencionPaciente.Application.PatientsServices.CommandPatientsAssignConsultation;
using Clinica.AtencionPaciente.Domain.Entities;
using Clinica.AtencionPaciente.Domain.Factories;
using Clinica.AtencionPaciente.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinica.AtencionPaciente.Application.PatientsServices.CommandPatientsToAssignConsultation
{
    public class PatientsAssignConsultationHandler 
        : IRequestHandler<PatientsAssignConsultation, PatientsAssignConsultationDTO>
    {

        private List<Ninno> ninnosPediatria;

        private List<Ninno> ninnosUrgencias;

        private List<Joven> jovenesGeneral;

        private List<Joven> jovenesUrgencias;

        private List<Anciano> ancianosGeneral;

        private List<Anciano> ancianosUrgencias;

        private readonly IFactory factory;

        private readonly IRepository repository;

        public PatientsAssignConsultationHandler(IFactory factory, IRepository repository)
        {
            this.factory = factory;
            this.repository = repository;
        }

        public async Task<PatientsAssignConsultationDTO> Handle(PatientsAssignConsultation request,
            CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("la pecicion para asignacion es nula");

            //clasicar los pacientes segun la prioridad
            await ClasificarPacientesSegunPrioridad(cancellationToken);

            //consultar las consultas clinicas que esten desocupadas segun el tipo
            var consultasDesocupadasPediatria = await this.repository.GetAll<ConsultaClinica>(
                x => x.Estado == EstadoEnum.Desocupado && x.TipoConsulta == TipoConsultaEnum.Pediatria,
                cancellationToken);

            var consultasDesocupadasGeneral = await this.repository.GetAll<ConsultaClinica>(
                x => x.Estado == EstadoEnum.Desocupado && x.TipoConsulta == TipoConsultaEnum.Urgencias,
                cancellationToken);

            var consultasDesocupadasUrgencias = await this.repository.GetAll<ConsultaClinica>(
                x => x.Estado == EstadoEnum.Desocupado && x.TipoConsulta == TipoConsultaEnum.MedicinaGeneral,
                cancellationToken);

            //asignar ninos a pediatria
            var noFaltanNiññosPediatria = await AsignarPacientesAConsulta<Ninno>(consultasDesocupadasPediatria, 
                ninnosPediatria, cancellationToken);

            //asignar ninnos a hurgencias
            var noFaltanNiññosUregncias = await AsignarPacientesAConsulta<Ninno>(consultasDesocupadasUrgencias, 
                this.ninnosUrgencias, cancellationToken);

            //asignar jovenes a general
            var noFaltanJovensGeneral = await AsignarPacientesAConsulta<Joven>(consultasDesocupadasGeneral, 
                this.jovenesGeneral, cancellationToken);

            //asiganr jovens a urgencias
            var noFaltanJovensUrgencias = await AsignarPacientesAConsulta<Joven>(consultasDesocupadasUrgencias, 
                this.jovenesUrgencias, cancellationToken);

            //asiganr anciano a general
            var noFaltanAncianosGeneral = await AsignarPacientesAConsulta<Anciano>(consultasDesocupadasGeneral, 
                this.ancianosGeneral, cancellationToken);

            //asiganr anciano a urgencias
            var noFaltanAncianosUrgencias = await AsignarPacientesAConsulta<Anciano>(consultasDesocupadasUrgencias, 
                this.ancianosUrgencias, cancellationToken);

            return new PatientsAssignConsultationDTO
            {
                noFaltanAncianosGeneral = noFaltanAncianosGeneral,
                noFaltanAncianosUrgencias = noFaltanAncianosUrgencias,
                noFaltanJovensGeneral = noFaltanJovensGeneral,
                noFaltanJovensUrgencias = noFaltanJovensUrgencias,
                noFaltanNiññosPediatria = noFaltanNiññosPediatria,
                noFaltanNiññosUregncias = noFaltanNiññosUregncias
            };
        }

        private async Task ClasificarPacientesSegunPrioridad(CancellationToken cancellationToken)
        {
            //clasificar pacientes segun prioridad y que no se les alla asignado una consulta
            this.ninnosPediatria = await this.repository.GetAll<Ninno>(
                x => x.Prioridad <= 4 && x.Hospital == null,
                x => x.Prioridad,
                cancellationToken);

            this.ninnosUrgencias = await this.repository.GetAll<Ninno>(
                x => x.Prioridad > 4 && x.Hospital == null,
                x => x.Prioridad,
                cancellationToken);

            this.jovenesGeneral = await this.repository.GetAll<Joven>(
                x => x.Prioridad < 4 && x.Hospital == null,
                x => x.Prioridad,
                cancellationToken);

            this.jovenesUrgencias = await this.repository.GetAll<Joven>(
                x => x.Prioridad > 4 && x.Hospital == null,
                x => x.Prioridad,
                cancellationToken);

            this.ancianosGeneral = await this.repository.GetAll<Anciano>(
                x => x.Prioridad < 4 && x.Hospital == null,
                x => x.Prioridad,
                cancellationToken);

            this.ancianosUrgencias = await this.repository.GetAll<Anciano>(
                x => x.Prioridad > 4 && x.Hospital == null,
                x => x.Prioridad,
                cancellationToken);
        }

        private async Task<bool> AsignarPacientesAConsulta<T>(List<ConsultaClinica> consultasClinicas, 
            List<T> pacientes, CancellationToken cancellationToken) where T : Paciente
        {
            if (consultasClinicas != null)
            {
                //creamos un hospital en sala pendientes y con asignacion de consultas y pacientes
                var hospital = (Hospital)this.factory.CreateHospital(SalaEnum.pendiente);
                await this.repository.Save<Hospital>(hospital, cancellationToken);
                    

                foreach (var paciente in pacientes)
                {
                    if (paciente is Ninno)
                    {
                        Ninno ninno = (Ninno)Convert.ChangeType(paciente, typeof(Ninno));

                        ninno = (Ninno)factory.CreateNinno(
                            relacionPesoEstatura: ninno.RelacionPesoEstatura,
                            nombre: ninno.Nombre,
                            edad: ninno.Edad,
                            numeroHistoriasClinico: ninno.NumeroHistoriasClinico,
                            prioridad: ninno.Prioridad,
                            riesgo: ninno.Riesgo,
                            hospital: new List<Hospital> { hospital },
                            id: Guid.Parse(ninno.Id));

                        await this.repository.Update<Ninno>(ninno, cancellationToken);
                    }

                    else if (paciente is Joven)
                    {
                        Joven joven = (Joven)Convert.ChangeType(paciente, typeof(Joven));

                        joven = (Joven)factory.CreateJoven(
                            annosFumando: joven.AnnosFumando,
                            esFumador: joven.EsFumador,
                            nombre: joven.Nombre,
                            edad: joven.Edad,
                            numeroHistoriasClinico: joven.NumeroHistoriasClinico,
                            prioridad: joven.Prioridad,
                            riesgo: joven.Riesgo,
                            hospital: new List<Hospital> { hospital },
                            id: Guid.Parse(joven.Id));

                        await this.repository.Update<Joven>(joven, cancellationToken);
                    }

                    else if (paciente is Anciano)
                    {
                        Anciano anciano = (Anciano)Convert.ChangeType(paciente, typeof(Anciano));

                        anciano = (Anciano)factory.CreateAnciano(
                            tieneDieta: anciano.TieneDieta,
                            nombre: anciano.Nombre,
                            edad: anciano.Edad,
                            numeroHistoriasClinico: anciano.NumeroHistoriasClinico,
                            prioridad: anciano.Prioridad,
                            riesgo: anciano.Riesgo,
                            hospital: new List<Hospital> { hospital },
                            id: Guid.Parse(anciano.Id));

                        await this.repository.Update<Anciano>(anciano, cancellationToken);
                    }
                }

                foreach (var consulta in consultasClinicas)
                {
                    var consultaPediatria = (ConsultaClinica)factory.CreateConsultaClinica(
                        cantidadPacientes: consulta.CantidadPacientes,
                        tipoConsulta: consulta.TipoConsulta,
                        estado: consulta.Estado,
                        especialistaId: consulta.EspecialistaId,
                        hospital: new List<Hospital> { hospital },
                        id: Guid.Parse(consulta.Id));

                    await this.repository.Update<ConsultaClinica>(consultaPediatria, cancellationToken);
                }

                return true;
            }
            else
            {
                //se crea un hospital en sala de espera sin asignacion de consultas solo pacientes
                var hospital = (Hospital)this.factory.CreateHospital(SalaEnum.Espera);
                await this.repository.Save<Hospital>(hospital, cancellationToken);

                foreach (var paciente in pacientes)
                {
                    if (paciente is Ninno)
                    {
                        Ninno ninno = (Ninno)Convert.ChangeType(paciente, typeof(Ninno));

                        ninno = (Ninno)factory.CreateNinno(
                            relacionPesoEstatura: ninno.RelacionPesoEstatura,
                            nombre: ninno.Nombre,
                            edad: ninno.Edad,
                            numeroHistoriasClinico: ninno.NumeroHistoriasClinico,
                            prioridad: ninno.Prioridad,
                            riesgo: ninno.Riesgo,
                            hospital: new List<Hospital> { hospital },
                            id: Guid.Parse(ninno.Id));

                        await this.repository.Update<Ninno>(ninno, cancellationToken);
                    }

                    else if (paciente is Joven)
                    {
                        Joven joven = (Joven)Convert.ChangeType(paciente, typeof(Joven));

                        joven = (Joven)factory.CreateJoven(
                            annosFumando: joven.AnnosFumando,
                            esFumador: joven.EsFumador,
                            nombre: joven.Nombre,
                            edad: joven.Edad,
                            numeroHistoriasClinico: joven.NumeroHistoriasClinico,
                            prioridad: joven.Prioridad,
                            riesgo: joven.Riesgo,
                            hospital: new List<Hospital> { hospital },
                            id: Guid.Parse(joven.Id));

                        await this.repository.Update<Joven>(joven, cancellationToken);
                    }

                    else if (paciente is Anciano)
                    {
                        Anciano anciano = (Anciano)Convert.ChangeType(paciente, typeof(Anciano));

                        anciano = (Anciano)factory.CreateAnciano(
                            tieneDieta: anciano.TieneDieta,
                            nombre: anciano.Nombre,
                            edad: anciano.Edad,
                            numeroHistoriasClinico: anciano.NumeroHistoriasClinico,
                            prioridad: anciano.Prioridad,
                            riesgo: anciano.Riesgo,
                            hospital: new List<Hospital> { hospital },
                            id: Guid.Parse(anciano.Id));

                        await this.repository.Update<Anciano>(anciano, cancellationToken);
                    }
                }

                return false;
            }
        }

    }
}
