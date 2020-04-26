using VegaIT.Core.DTOs;
using VegaIT.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace VegaIT.Core.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DiagnosisKeyDTO, DiagnosisKey>();
            CreateMap<DiagnosisKey, DiagnosisKeyDTO>();
        }
    }
}
