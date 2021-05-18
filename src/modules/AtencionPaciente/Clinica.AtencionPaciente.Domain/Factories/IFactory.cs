using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Factories
{
    public interface IFactory
    {
        public Entity CreateAnciano(bool tieneDieta, string nombre, int edad,
            string numeroHistoriasClinico, double prioridad, double riesgo, List<Hospital> hospital = null, Guid ? id = null);

        public Entity CreateNinno(int relacionPesoEstatura, string nombre, int edad, string numeroHistoriasClinico, 
            double prioridad, double riesgo, List<Hospital> hospital = null, Guid ? id = null);

        public Entity CreateJoven(int annosFumando, bool esFumador, string nombre, int edad, string numeroHistoriasClinico, 
            double prioridad, double riesgo, List<Hospital> hospital = null, Guid? id = null);

        public Entity CreateConsultaClinica(int cantidadPacientes, TipoConsultaEnum tipoConsulta, EstadoEnum estado,
            string especialistaId, List<Hospital> hospital = null, Guid? id = null);

        public Entity CreateHospital(string pacientesId, string consultasClinicasId, SalaEnum sala, Guid? id = null);

        public Entity CreateEspecialista(string nombre, Guid? id = null);
    }
}
