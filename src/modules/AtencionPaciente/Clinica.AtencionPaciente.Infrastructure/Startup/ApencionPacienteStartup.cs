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
using System.Reflection;
using Clinica.AtencionPaciente.Application.ClinicServices.CommandClinicCreate;
using Clinica.AtencionPaciente.Application.PatientServices.QueyBoyUrgentlist;
using Clinica.AtencionPaciente.Application.PatientServices.QueryYourngUrgentList;
using Clinica.AtencionPaciente.Application.PatientServices.QueryOldUrgentList;
using Clinica.AtencionPaciente.Application.PatientServices.QueryYoungUrgentSmokerslist;
using Clinica.AtencionPaciente.Application.PatientServices.QueryOlder;

namespace Clinica.AtencionPaciente.Infrastructure.Startup
{
    public static class ApencionPacienteStartup
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
            services.AddDbContext<AtencionContext>(
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
            services.AddMediatR(typeof(ClinicCreate).GetTypeInfo().Assembly); 
            services.AddMediatR(typeof(BoyUrgentlist).GetTypeInfo().Assembly); 
            services.AddMediatR(typeof(YourngUrgentList).GetTypeInfo().Assembly); 
            services.AddMediatR(typeof(OldUrgentList).GetTypeInfo().Assembly); 
            services.AddMediatR(typeof(YoungUrgentSmokerslist).GetTypeInfo().Assembly); 
            services.AddMediatR(typeof(Older).GetTypeInfo().Assembly);
        }
    }
}
