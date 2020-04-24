using Core.DTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Core.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<HealthUser, HealthUserDTO>();
            CreateMap<HealthUserDTO, HealthUser>();
            CreateMap<DiagnosisDTO, Diagnosis>();
            CreateMap<Diagnosis, DiagnosisDTO>();
            CreateMap<DiagnosisKeyDTO, DiagnosisKey>();
            CreateMap<DiagnosisKey, DiagnosisKeyDTO>();
        }
    }
}
