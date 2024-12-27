using System.Net;

namespace Finance.Exception.ExceptionModel;

public class InvalidRequestException : ExceptionMessage{
    
    public InvalidRequestException(List<string> errors) 
        : base(errors, HttpStatusCode.BadRequest){
    }
}