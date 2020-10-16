using System;
using System.Runtime.Serialization;

namespace StoreWarehouse.Core.Exceptions
{
    [Serializable]
    public class ExistSubCategoryNameException : Exception
    {
        public ExistSubCategoryNameException()
        {
        }

        public ExistSubCategoryNameException(string message) : base(message)
        {
        }

        public ExistSubCategoryNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExistSubCategoryNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}