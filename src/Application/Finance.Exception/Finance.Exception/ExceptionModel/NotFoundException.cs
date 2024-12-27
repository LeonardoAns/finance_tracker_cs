using System.Net;

namespace Finance.Exception.ExceptionModel;

public class NotFoundException : ExceptionMessage{
    
    public NotFoundException(string message) 
        : base(message, HttpStatusCode.NotFound){
    }
    
}