using System;
using System.Runtime.Serialization;

public class WebApiException : Exception 
{
    public WebApiException() 
    {

    }

    public WebApiException(string message) : base(message)
    {

    }

    public WebApiException(string message, Exception innerException) : base(message, innerException)
    {

    }
    
    public WebApiException(SerializationInfo info, StreamingContext context) : base(info, context)
    {

    }
}