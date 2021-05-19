using AutoMapper;
using Clinica.AtencionPaciente.Application.ClinicServices.CommandClinicCreate;
using Clinica.AtencionPaciente.Application.PatientServices.CommandBoyCreate;
using Clinica.AtencionPaciente.Application.PatientServices.CommandOldCreate;
using Clinica.AtencionPaciente.Application.PatientServices.CommandYoungCreate;
using Clinica.AtencionPaciente.Application.PatientServices.QueryOlder;
using Clinica.AtencionPaciente.Application.PatientServices.QueryOldUrgentList;
using Clinica.AtencionPaciente.Application.PatientServices.QueryYoungUrgentSmokerslist;
using Clinica.AtencionPaciente.Application.PatientServices.QueryYourngUrgentList;
using Clinica.AtencionPaciente.Application.PatientServices.QueyBoyUrgentlist;
using Clinica.AtencionPaciente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinica.AtencionPaciente.Infrastructure.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            this.CreateMap<Joven, YoungCreateDTO>();
            this.CreateMap<Anciano, OldCreateDTO>();
            this.CreateMap<Ninno, BoyCreateDTO>();
            this.CreateMap<ConsultaClinica, ClinicCreateDTO>(); 
            this.CreateMap<Ninno, BoyUrgentlistDTO>(); 
            this.CreateMap<Joven, YourngUrgentListDTO>(); 
            this.CreateMap<Anciano, OldUrgentListDTO>();
            this.CreateMap<Joven, YoungUrgentSmokerslistDTO>(); 
            this.CreateMap<Anciano, OlderDTO>();
        }
    }
}
