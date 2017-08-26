using System;

namespace ESIConnectionLibrary.Exceptions
{
    public class ESIException : Exception
    {
        public ESIException(string message) : base(message)
        {
            
        }

        public ESIException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
