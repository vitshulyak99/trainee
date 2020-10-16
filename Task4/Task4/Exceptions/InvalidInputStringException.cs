using System;
using System.Runtime.Serialization;

namespace Task4.Exceptions
{
    [Serializable]
    public class InvalidInputStringException : Exception
    {
        public InvalidInputStringException()
        {
        }

        public InvalidInputStringException(string message) : base(message)
        {
        }

        public InvalidInputStringException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidInputStringException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}