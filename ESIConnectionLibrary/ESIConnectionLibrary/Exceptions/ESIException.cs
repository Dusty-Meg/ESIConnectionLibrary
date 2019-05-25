using System;

namespace ESIConnectionLibrary.Exceptions
{
    public class EsiException : Exception
    {
        public EsiException(string message) : base(message)
        {
            
        }

        public EsiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
