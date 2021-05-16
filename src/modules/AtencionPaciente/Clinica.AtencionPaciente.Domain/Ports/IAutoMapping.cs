﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Domain.Ports
{
    public interface IAutoMapping
    {
        public TDestination Map<TSource, TDestination>(TSource source);
    }
}
