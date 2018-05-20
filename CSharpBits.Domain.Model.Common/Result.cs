using System;
using System.Collections.Generic;

namespace CSharpBits.Domain.Model.Common
{
    public class Result
    {
        public bool Success { get; set; }
        public bool Failed { get; set; }
        public string SimpleMessage { get; set; }
        public string Message { get; set; }
        public Exception InnerException { get; set; }
        public List<string> Messages { get; set; }

        public Result()
        {
            Success = false;
            Failed = false;
            SimpleMessage = string.Empty;
            Message = string.Empty;
            InnerException = null;
            Messages = null;
        }

    }
}
