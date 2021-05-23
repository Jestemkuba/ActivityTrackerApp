using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityTrackerApp.Models
{
    class ApiErrorResponse
    {
        public bool Succeeded { get; set; }
        public List<Error> Errors { get; set; }
    }

    public class Error
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
