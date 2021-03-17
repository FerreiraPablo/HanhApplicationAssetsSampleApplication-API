using System;
using System.Runtime.Serialization;

namespace Hahn.ApplicationProcess.February2021.Domain.BusinessLogic.Assets.Exceptions
{
    public class AssetValidationException : Exception
    {
        public AssetValidationException()
        {
        }

        public AssetValidationException(string message) : base(message)
        {
        }

        public AssetValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AssetValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
