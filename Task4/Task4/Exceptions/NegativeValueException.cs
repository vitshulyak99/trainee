using System;
using System.Runtime.Serialization;

namespace Task4.Exceptions
{
    [Serializable]
    public class NegativeOrZeroValueException : ArgumentException
    {
        public NegativeOrZeroValueException()
        {
        }

        public NegativeOrZeroValueException(string message) : base(message)
        {
        }

        public NegativeOrZeroValueException(string v1, string v2):base(v1,v2)
        {
        }

        public NegativeOrZeroValueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativeOrZeroValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}