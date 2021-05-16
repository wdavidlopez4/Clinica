using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration; //getConnectionString
using Clinica.AtencionPaciente.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using MediatR;
using Clinica.AtencionPaciente.Application.PatientServices.CommandYoungCreate;
using Clinica.AtencionPaciente.Application.PatientServices.CommandOldCreate;
using Clinica.AtencionPaciente.Application.PatientServices.CommandBoyCreate;
using Clinica.AtencionPaciente.Application.hospitalService.CommandHospitalCreateOne;
using System.Reflection;

namespace Clinica.AtencionPaciente.Infrastructure.Startup
{
    public static class CoffeeClimateStartup
    {
        public static void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            InyectionContainer.Inyection(services);
            ConfigurationSqlServer(services, configuration);
            ConfigurarMapper(services);
            ConfigurarMediador(services);
        }

        private static void ConfigurationSqlServer(IServiceCollection services, IConfiguration configuration)
        {
            // entity framework db context
            string connString = configuration.GetConnectionString("CafeConnectionString"); //obtenemos la cadena de coneccion DESDE EL ARCHIVO APPSETTINGS
            services.AddDbContext<AtencionPacientesContex>(
                options => options.UseSqlServer(connString));
        }

        private static void ConfigurarMapper(IServiceCollection services)
        {
            //mapeo de entidades
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void ConfigurarMediador(IServiceCollection services)
        {
            services.AddMediatR(typeof(YoungCreate).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(OldCreate).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(BoyCreate).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(HospitalCreateOne).GetTypeInfo().Assembly);
        }
    }
}
