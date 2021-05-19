using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Application.Execptions
{
    public class EdadException : Exception
    {
        public EdadException(string name):base(name)
        {

        }
    }
}
