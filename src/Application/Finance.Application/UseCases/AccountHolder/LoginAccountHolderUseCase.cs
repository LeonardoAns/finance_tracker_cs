using Domain.IRepositories;
using Domain.Security;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Communication.AccountHolder.Request;
using Finance.Communication.AccountHolder.Response;
using Finance.Exception.ExceptionModel;

namespace Finance.Application.UseCases.AccountHolder;

using Domain.Entities;

public class LoginAccountHolderUseCase : ILoginAccountHolderUseCase{
    
    private readonly IAccountHolderRepository _accountHolderRepository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly ITokenGenerator _tokenGenerator;

    public LoginAccountHolderUseCase(IAccountHolderRepository accountHolderRepository, IPasswordEncripter passwordEncripter, ITokenGenerator tokenGenerator){
        _accountHolderRepository = accountHolderRepository;
        _passwordEncripter = passwordEncripter;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<AccountHolderResponseJson> Execute(LoginAccountHolderRequestJson accountHolderRequest){
        AccountHolder? accountHolder = await _accountHolderRepository.GetByEmail(accountHolderRequest.Email) ?? 
                                       throw new BadCredentialsExceptions("Email Not Found For This Account Holder");

        bool passwordMatch = _passwordEncripter.Verify(accountHolderRequest.Password, accountHolder.Password);
        if (!passwordMatch){
            throw new BadCredentialsExceptions("Email or Password Invalid");
        }

        return new AccountHolderResponseJson(_tokenGenerator.GenerateToken(accountHolder));
    }
}