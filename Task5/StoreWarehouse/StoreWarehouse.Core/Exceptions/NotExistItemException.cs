using System;
using System.Runtime.Serialization;

namespace StoreWarehouse.Core.Exceptions
{
    [Serializable]
    public class NotExistItemException : Exception
    {
        public NotExistItemException()
        {
        }

        public NotExistItemException(string message) : base(message)
        {
        }

        public NotExistItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotExistItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}