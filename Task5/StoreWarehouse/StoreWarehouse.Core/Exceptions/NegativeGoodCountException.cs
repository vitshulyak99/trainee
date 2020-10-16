using System;
using System.Runtime.Serialization;

namespace StoreWarehouse.Core.Exceptions
{
    [Serializable]
    public class NegativeGoodCountException : Exception
    {
        public NegativeGoodCountException()
        {
        }

        public NegativeGoodCountException(string message) : base(message)
        {
        }

        public NegativeGoodCountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegativeGoodCountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}