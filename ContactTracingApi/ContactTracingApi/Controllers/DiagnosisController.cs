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

        private readonly IDiagnosisKeyService _diagnosisKeyService;

        public DiagnosisController(IMapper mapper, IDiagnosisService diagnosisService, IDiagnosisKeyService diagnosisKeyService)
        {
            _mapper = mapper;
            _diagnosisService = diagnosisService;
            _diagnosisKeyService = diagnosisKeyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagnosisDTO>>> getDiagnosesAfterDate(DateTime date)
        {
            var diagnoses = await _diagnosisService.GetDiagnosesAfterDate(date);

            // TODO figure this out
            var diagnosisKey = await _diagnosisKeyService.GetAllDiagnosisKeys();

            return Ok(diagnoses);
        }

        [HttpPost]
        public async Task<ActionResult<DiagnosisDTO>> postDiagnosis(DiagnosisDTO diagnosisDTO)
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
