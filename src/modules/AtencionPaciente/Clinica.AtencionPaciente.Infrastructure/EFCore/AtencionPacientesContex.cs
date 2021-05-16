using Clinica.AtencionPaciente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Infrastructure.EFCore
{
    public class AtencionPacientesContex : DbContext
    {
        public DbSet<Anciano> Ancianos  { get; set; }

        public DbSet<ConsultaClinica> ConsultasClinicas  { get; set; }

        public DbSet<Especialista> Especialistas  { get; set; }

        public DbSet<Hospital> Hospitales  { get; set; }

        public DbSet<Joven> Jovenes  { get; set; }

        public DbSet<Ninno> Ninnos  { get; set; }

        public AtencionPacientesContex(DbContextOptions<AtencionPacientesContex> options) : base(options)
        {
            
        }

    }
}
