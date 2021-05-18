using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Factories
{
    public class Factory : IFactory
    {
        public Entity CreateAnciano(bool tieneDieta, string nombre, int edad, 
            string numeroHistoriasClinico, double prioridad, double riesgo, List<Hospital> hospital = null, Guid ? id = null)
        {
            return new Anciano(tieneDieta, nombre, edad, numeroHistoriasClinico, prioridad, riesgo, hospital, id);
        }

        public Entity CreateNinno(int relacionPesoEstatura, string nombre, int edad, string numeroHistoriasClinico, 
            double prioridad, double riesgo, List<Hospital> hospital = null, Guid ? id = null)
        {
            return new Ninno(relacionPesoEstatura, nombre, edad, numeroHistoriasClinico, prioridad, riesgo, hospital, id);
        }

        public Entity CreateJoven(int annosFumando, bool esFumador, string nombre, int edad, string numeroHistoriasClinico, 
            double prioridad, double riesgo, List<Hospital> hospital = null, Guid? id = null)
        {
            return new Joven(annosFumando, esFumador, nombre, edad, numeroHistoriasClinico, prioridad, riesgo, hospital, id);
        }

        public Entity CreateConsultaClinica(int cantidadPacientes, TipoConsultaEnum tipoConsulta, EstadoEnum estado, 
            string especialistaId, List<Hospital> hospital = null, Guid? id = null)
        {
            return new ConsultaClinica(cantidadPacientes, tipoConsulta, estado, especialistaId, hospital, id);
        }

        public Entity CreateHospital(string pacientesId, string consultasClinicasId, SalaEnum sala, Guid? id = null)
        {
            return new Hospital(pacientesId, consultasClinicasId, sala, id);
        }

        public Entity CreateEspecialista(string nombre, Guid? id = null)
        {
            return new Especialista(nombre, id);
        }

        public Entity CreateHospital(SalaEnum sala, string pacientesId = null, string consultasClinicasId = null, Guid? id = null)
        {
            return new Hospital(sala, pacientesId, consultasClinicasId, id);
        }
    }
}
