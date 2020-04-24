using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }

        public ICollection<DiagnosisKey> DiagnosisKeys { get; set; }

        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public bool Sent { get; set; }

        public bool Confirmed { get; set; }
    }
}
