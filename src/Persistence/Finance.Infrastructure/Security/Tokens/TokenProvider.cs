using Domain.Security;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security.Tokens;

public class TokenProvider : ITokenProvider {

    private IHttpContextAccessor _contextAccessor;

    public TokenProvider(IHttpContextAccessor contextAccessor){
        _contextAccessor = contextAccessor;
    }

    public string TokenOnRequest(){
        var auth = _contextAccessor.HttpContext!.Request.Headers["Authorization"].ToString();
        if (string.IsNullOrEmpty(auth)){
            throw new InvalidOperationException("Authorization Header is Missing");
        }

        return auth["Bearer".Length..].Trim();
    }
}