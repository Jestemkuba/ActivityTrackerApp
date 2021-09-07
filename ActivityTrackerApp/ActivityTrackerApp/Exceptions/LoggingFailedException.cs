using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityTrackerApp.Exceptions
{
    class LoggingFailedException : Exception
    {
        public LoggingFailedException()
        {
        }

        public LoggingFailedException(string message) : base(message)
        {
        }
    }
}
