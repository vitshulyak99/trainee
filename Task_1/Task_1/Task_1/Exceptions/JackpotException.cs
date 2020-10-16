using System;
using System.Runtime.Serialization;

namespace Task_1.Exceptions
{
    [Serializable]
    internal class JackpotException : Exception
    {

        public JackpotException(string message) : base(message)
        {
        }

        public JackpotException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JackpotException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}