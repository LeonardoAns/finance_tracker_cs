using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Security;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Security.Tokens;

public class TokenGenerator : ITokenGenerator {

    private readonly uint _expirationTimeMinutes;
    private readonly string _signingKey;

    public TokenGenerator(uint expirationTimeMinutes, string signingKey){
        _expirationTimeMinutes = expirationTimeMinutes;
        _signingKey = signingKey;
    }

    public string GenerateToken(AccountHolder accountHolder){
        string rolesString = string.Join(",", accountHolder.Roles); 
        
        var claims = new List<Claim>(){
            new Claim(ClaimTypes.Name, accountHolder.FullName),
            new Claim(ClaimTypes.Sid, accountHolder.Id.ToString()),
            new Claim(ClaimTypes.Role, rolesString)
        };

        var token = new SecurityTokenDescriptor(){
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(token);
        return tokenHandler.WriteToken(securityToken);
    }

    private SymmetricSecurityKey SecurityKey(){
        var key = Encoding.UTF8.GetBytes(_signingKey);
        return new SymmetricSecurityKey(key);
    }
    
}