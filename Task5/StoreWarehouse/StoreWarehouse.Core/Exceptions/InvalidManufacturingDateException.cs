using System;
using System.Runtime.Serialization;

namespace StoreWarehouse.Core.Exceptions
{
    [Serializable]
    public class InvalidManufacturingDateException : Exception
    {
        public InvalidManufacturingDateException()
        {
        }

        public InvalidManufacturingDateException(string message) : base(message)
        {
        }

        public InvalidManufacturingDateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidManufacturingDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}