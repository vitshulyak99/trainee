using System;
using System.Runtime.Serialization;

namespace StoreWarehouse.Core.Exceptions
{
    [Serializable]
    public class InvalidExpirationDateException : Exception
    {
        public InvalidExpirationDateException()
        {
        }

        public InvalidExpirationDateException(string message) : base(message)
        {
        }

        public InvalidExpirationDateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidExpirationDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}