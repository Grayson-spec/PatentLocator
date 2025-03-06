using System;
using System.Runtime.Serialization;


// Document later. - Grayson
namespace backend.Infrastructure
{
    [Serializable]
    public class ServiceException : Exception
    {
        public ServiceException() { }
        public ServiceException(string message) 
            : base(message) { }
    }
}
