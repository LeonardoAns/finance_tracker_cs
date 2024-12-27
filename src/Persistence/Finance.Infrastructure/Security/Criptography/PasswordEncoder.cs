using Domain.Security;

namespace Infrastructure.Security.Criptography;

public class PasswordEncoder : IPasswordEncripter{

    public string Encrypt(string password){
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string hashPassword) => BCrypt.Net.BCrypt.Verify(password, hashPassword);
}