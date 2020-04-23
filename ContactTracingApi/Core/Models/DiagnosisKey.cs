using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class DiagnosisKey
    {
        [Key]
        public int Id { get; set; }

        public string DailyKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool Sent { get; set; }

        [Required]
        public bool Confirmed { get; set; }

        [Required]
        public string HealthID { get; set; }
    }
}
