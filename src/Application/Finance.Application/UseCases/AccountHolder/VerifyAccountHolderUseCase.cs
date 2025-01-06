using Domain.IRepositories;
using Domain.IUnitOfWork;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.IUseCases.Email;
using Finance.Exception.ExceptionModel;

namespace Finance.Application.UseCases.AccountHolder;

using Domain.Entities;

public class VerifyAccountHolderUseCase : IVerifyAccountHolderUseCase {

    private readonly IAccountHolderRepository _accountHolderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISendWelcomeEmailUseCase _sendWelcomeEmail;

    public VerifyAccountHolderUseCase(IAccountHolderRepository accountHolderRepository, IUnitOfWork unitOfWork, ISendWelcomeEmailUseCase sendWelcomeEmail){
        _accountHolderRepository = accountHolderRepository;
        _unitOfWork = unitOfWork;
        _sendWelcomeEmail = sendWelcomeEmail;
    }

    public async Task Execute(string verificationCode){
        AccountHolder accountHolder = await _accountHolderRepository.FindByVerificationCode(verificationCode)
                                      ?? throw new NotFoundException($"Account Holder Not Found");
        accountHolder.VerificationCode = null;
        accountHolder.Enabled = true;
        _accountHolderRepository.Update(accountHolder);
        await _unitOfWork.Commit();
        await Task.Delay(TimeSpan.FromSeconds(10));
        await _sendWelcomeEmail.Execute(accountHolder);

    }
}