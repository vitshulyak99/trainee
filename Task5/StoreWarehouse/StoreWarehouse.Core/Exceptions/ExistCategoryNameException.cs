using System;
using System.Runtime.Serialization;

namespace StoreWarehouse.Core.Exceptions
{
    [Serializable]
    public class ExistCategoryNameException : Exception
    {
        public ExistCategoryNameException()
        {
        }

        public ExistCategoryNameException(string message) : base(message)
        {
        }

        public ExistCategoryNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExistCategoryNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}