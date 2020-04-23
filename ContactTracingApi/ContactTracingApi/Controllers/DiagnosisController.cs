using System;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactTracingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DiagnosisController : ControllerBase
    {

        private readonly IMapper _mapper;

        public DiagnosisController()
        {
        }

        [HttpPost]
        public async Task<ActionResult<DiagnosisKey>> submitDiagnosis()
        {
            return Ok("123");
        }
    }
}
