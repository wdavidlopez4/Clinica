using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Factories
{
    public interface IFactoryAtencionPaciente
    {
        public Entity CreateAnciano(bool tieneDieta, string nombre, int edad,
            string numeroHistoriasClinico, string hospitalId, Guid? id = null);

        public Entity CreateNinno(int relacionPesoEstatura, string nombre, int edad, string numeroHistoriasClinico,
            string hospitalId, Guid? id = null);

        public Entity CreateJoven(bool esFumador, string nombre, int edad, string numeroHistoriasClinico,
            string hospitalId, Guid? id = null);

        public Entity CreateConsultaClinica(int cantidadPacientes, TipoConsultaEnum tipoConsulta, EstadoEnum estado,
            string especialistaId, Guid? id = null);
    }
}
