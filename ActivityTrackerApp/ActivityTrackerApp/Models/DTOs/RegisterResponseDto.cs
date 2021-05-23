using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityTrackerApp.Models.DTOs
{
    class RegisterResponseDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string ErrorMessage { get; set; }
    }
}
