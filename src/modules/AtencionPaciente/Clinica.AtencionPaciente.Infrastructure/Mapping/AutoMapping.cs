﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Infrastructure.Mapping
{
    public class AutoMapping
    {
        private readonly IMapper mapper;

        public AutoMapping(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            try
            {
                return mapper.Map<TSource, TDestination>(source);
            }
            catch (Exception e)
            {

                throw new Exception($"no se pudo mapear la entidad: {e.Message}");
            }
        }
    }
}
