using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }

        public IEnumerable<DiagnosisKey> DiagnosisKeys { get; set; }

        public DateTime Date { get; set; }
    }
}
