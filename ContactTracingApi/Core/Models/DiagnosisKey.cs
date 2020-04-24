using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class DiagnosisKey
    {
        [Key]
        public int Id { get; set; }

        public string DailyKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Diagnosis Diagnosis { get; set; }
    }
}
