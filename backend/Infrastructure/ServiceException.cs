using System;
using System.Runtime.Serialization;

namespace backend.Infrastructure
{
    // Custom exception class for service-related errors
    [Serializable]
    public class ServiceException : Exception
    {
        // Default constructor
        public ServiceException() { }

        // Constructor that accepts a message
        public ServiceException(string message) 
            : base(message) { }

        // Constructor that accepts a message and an inner exception
        public ServiceException(string message, Exception innerException)
            : base(message, innerException) { }

        // Constructor for deserialization (required for exceptions that are serialized)
        protected ServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
