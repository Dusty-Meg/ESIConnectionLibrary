using System;

namespace ESIConnectionLibrary.Exceptions
{
    public class ESIException : Exception
    {
        public ESIException(string message) : base(message)
        {
            
        }

        public ESIException(string message, string stackTrace, Exception innerException) : base(message, innerException)
        {
            StackTrace = stackTrace;
        }

        public override string StackTrace { get; }
    }
}
