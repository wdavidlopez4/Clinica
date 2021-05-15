using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Factories
{
    public class FactoryAtencionPaciente : IFactoryAtencionPaciente
    {
        public Entity CreateAnciano(bool tieneDieta, string nombre, int edad, 
            string numeroHistoriasClinico, string hospitalId, Guid? id = null)
        {
            return new Anciano(tieneDieta, nombre, edad, numeroHistoriasClinico, hospitalId, id);
        }
    }
}
