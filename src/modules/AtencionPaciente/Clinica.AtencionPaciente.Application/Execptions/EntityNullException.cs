using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.Execptions
{
    public class EntityNullException : Exception
    {
        public EntityNullException(string name):base(name)
        {

        }
    }
}
