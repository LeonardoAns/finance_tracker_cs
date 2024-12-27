namespace Domain.Security;

public interface ITokenProvider {
    string TokenOnRequest();
}