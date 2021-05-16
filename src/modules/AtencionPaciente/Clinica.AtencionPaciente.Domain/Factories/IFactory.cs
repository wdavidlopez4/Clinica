using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Factories
{
    public interface IFactory
    {
        public Entity CreateAnciano(bool tieneDieta, string nombre, int edad,
            string numeroHistoriasClinico, string hospitalId, double prioridad, double riesgo, Guid? id = null);

        public Entity CreateNinno(int relacionPesoEstatura, string nombre, int edad, string numeroHistoriasClinico,
            string hospitalId, double prioridad, double riesgo, Guid? id = null);

        public Entity CreateJoven(int annosFumando, bool esFumador, string nombre, int edad, string numeroHistoriasClinico,
            string hospitalId, double prioridad, double riesgo, Guid? id = null);

        public Entity CreateConsultaClinica(int cantidadPacientes, TipoConsultaEnum tipoConsulta, EstadoEnum estado,
            string especialistaId, Guid? id = null);

        public Entity CreateHospital(List<Paciente> pacientes, List<ConsultaClinica> consultasClinicas, Guid? id = null);

        public Entity CreateHospital(Paciente paciente, ConsultaClinica consultasClinica, Guid? id = null);

        public Entity CreateHospital(Guid? id = null);

        public Entity CreateEspecialista(string nombre, Guid? id = null);
    }
}
