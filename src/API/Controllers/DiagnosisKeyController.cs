using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VegaIT.Core.DTOs;
using VegaIT.Core.Models;
using VegaIT.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace VegaIT.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiagnosisKeyController : ControllerBase
    {

        private readonly IMapper _mapper;

        private readonly IDiagnosisKeyService _diagnosisKeyService;

        public DiagnosisKeyController(IMapper mapper, IDiagnosisKeyService diagnosisKeyService)
        {
            _mapper = mapper;
            _diagnosisKeyService = diagnosisKeyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagnosisKeyDTO>>> GetDiagnosesKeys()
        {
            var diagnoses = await _diagnosisKeyService.GetLatestDiagnosisKeys();
               
            return Ok(diagnoses);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<DiagnosisKeyDTO>>> PostDiagnosisKeys(IEnumerable<DiagnosisKeyDTO> diagnosisDTO)
        {
            try
            {
                var diagnosis = _mapper.Map<IEnumerable<DiagnosisKey>>(diagnosisDTO);

                await _diagnosisKeyService.AddDiagnosisKeys(diagnosis);

                return Ok(diagnosis);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }
    }
}
