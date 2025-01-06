namespace Finance.Application.IUseCases.Email;

using Domain.Entities;

public interface ISendWelcomeEmailUseCase {
    Task Execute(AccountHolder accountHolder);
}