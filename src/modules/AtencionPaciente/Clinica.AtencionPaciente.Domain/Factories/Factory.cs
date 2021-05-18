using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Factories
{
    public class Factory : IFactory
    {
        public Entity CreateAnciano(bool tieneDieta, string nombre, int edad, 
            string numeroHistoriasClinico, double prioridad, double riesgo, string hospitalId = null, Guid ? id = null)
        {
            return new Anciano(tieneDieta, nombre, edad, numeroHistoriasClinico, prioridad, riesgo, hospitalId, id);
        }

        public Entity CreateNinno(int relacionPesoEstatura, string nombre, int edad, string numeroHistoriasClinico, 
            double prioridad, double riesgo, string hospitalId = null, Guid ? id = null)
        {
            return new Ninno(relacionPesoEstatura, nombre, edad, numeroHistoriasClinico, prioridad, riesgo, hospitalId, id);
        }

        public Entity CreateJoven(int annosFumando, bool esFumador, string nombre, int edad, string numeroHistoriasClinico, 
            double prioridad, double riesgo, string hospitalId = null, Guid? id = null)
        {
            return new Joven(annosFumando, esFumador, nombre, edad, numeroHistoriasClinico, prioridad, riesgo, hospitalId, id);
        }

        public Entity CreateConsultaClinica(int cantidadPacientes, TipoConsultaEnum tipoConsulta, EstadoEnum estado, 
            string especialistaId, string hospitalId = null, Guid? id = null)
        {
            return new ConsultaClinica(cantidadPacientes, tipoConsulta, estado, especialistaId, hospitalId, id);
        }

        public Entity CreateHospital(SalaEnum sala, List<Paciente> pacientes, List<ConsultaClinica> consultasClinicas, Guid? id = null)
        {
            return new Hospital(sala, pacientes, consultasClinicas, id);
        }

        public Entity CreateHospital(Paciente paciente, ConsultaClinica consultasClinica, Guid? id = null)
        {
            return new Hospital(paciente, consultasClinica, id);
        }

        public Entity CreateHospital(SalaEnum sala, Guid? id = null)
        {
            return new Hospital(sala, id);
        }

        public Entity CreateEspecialista(string nombre, Guid? id = null)
        {
            return new Especialista(nombre, id);
        }
    }
}
