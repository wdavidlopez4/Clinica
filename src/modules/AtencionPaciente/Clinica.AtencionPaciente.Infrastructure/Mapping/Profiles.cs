using AutoMapper;
using Clinica.AtencionPaciente.Application.hospitalService.CommandHospitalCreateOne;
using Clinica.AtencionPaciente.Application.PatientServices.CommandBoyCreate;
using Clinica.AtencionPaciente.Application.PatientServices.CommandOldCreate;
using Clinica.AtencionPaciente.Application.PatientServices.CommandYoungCreate;
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
            this.CreateMap<Hospital, HospitalCreateOneDTO>();
        }
    }
}
