namespace Finance.Application.IUseCases.AccountHolder;

public interface IVerifyAccountHolderUseCase {
    Task Execute(string verificationCode);
}