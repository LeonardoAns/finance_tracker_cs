using System.Net;

namespace Finance.Exception.ExceptionModel;

public class BadCredentialsExceptions : ExceptionMessage{
    
    public BadCredentialsExceptions(string message) : base(message, HttpStatusCode.Conflict){
    }
}