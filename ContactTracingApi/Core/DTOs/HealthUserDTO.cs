using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class HealthUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
