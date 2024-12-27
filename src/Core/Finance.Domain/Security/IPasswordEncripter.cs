namespace Domain.Security;

public interface IPasswordEncripter {
    public string Encrypt(string password);
    public bool Verify(string password, string hashPassword);
}