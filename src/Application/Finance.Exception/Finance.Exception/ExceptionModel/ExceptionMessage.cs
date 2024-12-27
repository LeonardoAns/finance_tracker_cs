using System.Net;

namespace Finance.Exception.ExceptionModel;

public class ExceptionMessage : SystemException{
    public string Message { get; set; } 
    public List<string> Errors { get; set; }
    public HttpStatusCode StatusCode { get; set; } 


    public ExceptionMessage(string message, HttpStatusCode statusCode) {
        Message = message;
        StatusCode = statusCode;
        Errors = new List<string>(); 
    }


    public ExceptionMessage(List<string> errors, HttpStatusCode statusCode) {
        Message = "Validation failed";
        Errors = errors;
        StatusCode = statusCode;
    }
}