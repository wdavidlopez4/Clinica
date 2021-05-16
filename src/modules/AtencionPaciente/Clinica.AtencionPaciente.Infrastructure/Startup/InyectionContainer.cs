using Clinica.AtencionPaciente.Domain.Factories;
using Clinica.AtencionPaciente.Domain.Ports;
using Clinica.AtencionPaciente.Infrastructure.Mapping;
using Clinica.AtencionPaciente.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Infrastructure.Startup
{
    public class InyectionContainer
    {
        public static void Inyection(IServiceCollection services)
        {
            services.AddScoped<IRepository, RepositorySQLServer>();
            services.AddScoped<IAutoMapping, AutoMapping>();
            services.AddScoped<IFactory, Factory>();
        }
    }
}
