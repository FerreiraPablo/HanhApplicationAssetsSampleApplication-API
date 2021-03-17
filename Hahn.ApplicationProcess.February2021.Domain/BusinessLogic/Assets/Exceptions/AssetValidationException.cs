using System;
using System.Runtime.Serialization;

namespace Hahn.ApplicationProcess.February2021.Domain.BusinessLogic.Assets.Exceptions
{
    /// <summary>
    /// Validation Exception for Asset Logic
    /// </summary>
    public class AssetValidationException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public AssetValidationException()
        {
        }

        /// <summary>
        /// Constructor with message
        /// </summary>
        /// <param name="message">Message to be included</param>
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
