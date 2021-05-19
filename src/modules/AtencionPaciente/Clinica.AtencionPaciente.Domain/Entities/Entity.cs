using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Entities
{
    public abstract class Entity
    {
        public string Id { get; protected set; }

        internal protected Entity(Guid? id = null)
        {
            this.Id = id == null ? Guid.NewGuid().ToString() : id.ToString();
        }
    }
}
