using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HealthID { get; set; }

        public string Token { get; set; }
    }
}
