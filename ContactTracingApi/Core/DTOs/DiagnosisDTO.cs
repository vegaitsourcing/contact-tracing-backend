using System;
using System.Collections.Generic;

namespace Core.DTOs
{
    public class DiagnosisDTO
    {
        public IEnumerable<DiagnosisKeyDTO> DiagnosisKeys { get; set; }

        public DateTime Date { get; set; }
    }
}
