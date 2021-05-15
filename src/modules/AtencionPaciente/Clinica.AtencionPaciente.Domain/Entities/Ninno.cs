using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public class Ninno : Paciente
    {
        public int RelacionPesoEstatura { get; private set; }

        internal Ninno(int relacionPesoEstatura, string nombre, int edad, string numeroHistoriasClinico,
            string hospitalId, Guid? id = null) : base(nombre, edad, numeroHistoriasClinico, hospitalId, id)
        {
            this.RelacionPesoEstatura = relacionPesoEstatura;
        }

        private Ninno()
        {
            //ef
        }
    }
}
