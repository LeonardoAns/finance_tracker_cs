namespace Finance.Application.IUseCases.Email;

public interface ISendVerificationEmailUseCase {
    Task Execute(Domain.Entities.AccountHolder accountHolder);
}