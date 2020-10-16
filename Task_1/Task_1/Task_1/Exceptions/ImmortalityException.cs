using System;
using System.Runtime.Serialization;

namespace Task_1.Exceptions
{
    [Serializable]
    internal class ImmortalityException : Exception
    {

        public ImmortalityException(string message) : base(message)
        {
        }

        public ImmortalityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ImmortalityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}