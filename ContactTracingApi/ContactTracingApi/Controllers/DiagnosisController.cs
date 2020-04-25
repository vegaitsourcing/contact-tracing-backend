using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactTracingApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiagnosisController : ControllerBase
    {

        private readonly IMapper _mapper;

        private readonly IDiagnosisService _diagnosisService;

        public DiagnosisController(IMapper mapper, IDiagnosisService diagnosisService)
        {
            _mapper = mapper;
            _diagnosisService = diagnosisService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagnosisDTO>>> GetDiagnosesAfterDate(DateTime date)
        {
            var diagnoses = await _diagnosisService.GetDiagnosesAfterDate(date);

            return Ok(diagnoses);
        }

        [HttpPost]
        public async Task<ActionResult<DiagnosisDTO>> PostDiagnosis(DiagnosisDTO diagnosisDTO)
        {
            try
            {
                var diagnosis = _mapper.Map<Diagnosis>(diagnosisDTO);

                await _diagnosisService.AddDiagnosis(diagnosis);
                return Ok(_mapper.Map<DiagnosisDTO>(diagnosis));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }
    }
}
