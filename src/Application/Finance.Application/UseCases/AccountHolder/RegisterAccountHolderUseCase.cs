using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Domain.Enums;
using Domain.IRepositories;
using Domain.IUnitOfWork;
using Domain.Security;
using Finance.Application.IUseCases.AccountHolder;
using Finance.Application.IUseCases.Email;
using Finance.Communication.AccountHolder;
using Finance.Communication.AccountHolder.Request;
using Finance.Exception.ExceptionModel;
using Finance.Exception.Validators;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Finance.Application.UseCases.AccountHolder;

using Domain.Entities;

public class RegisterAccountHolderUseCase : IRegisterAccountHolderUseCase {

    private readonly IAccountHolderRepository _accountHolderRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISendVerificationEmailUseCase _sendVerificationEmail;
    private readonly IPasswordEncripter _passwordEncripter;

    public RegisterAccountHolderUseCase(IAccountHolderRepository accountHolderRepository, 
        IMapper mapper, 
        IUnitOfWork unitOfWork, 
        ISendVerificationEmailUseCase sendVerificationEmail,
        IPasswordEncripter passwordEncripter){
        _accountHolderRepository = accountHolderRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _sendVerificationEmail = sendVerificationEmail;
        _passwordEncripter = passwordEncripter;
    }

    public async Task Execute(AccountHolderRequestJson accountHolderRequest){
        Validate(accountHolderRequest);
        if (await _accountHolderRepository.ExistsByEmail(accountHolderRequest.Email)){
            throw new BadCredentialsExceptions("Email Already Exists");
        }

        AccountHolder accountHolder = _mapper.Map<AccountHolder>(accountHolderRequest);
        accountHolder.VerificationCode = GenerateVerificationCode();
        accountHolder.Enabled = false;
        accountHolder.CreatedAt = DateTime.UtcNow;
        accountHolder.Roles = [Roles.User];
        accountHolder.Password = _passwordEncripter.Encrypt(accountHolder.Password);

        await _accountHolderRepository.AddAsync(accountHolder);
        await _sendVerificationEmail.Execute(accountHolder);
        await _unitOfWork.Commit();
    }
    
    private void Validate(AccountHolderRequestJson request){
        ValidationResult? validator = new AccountHolderValidator().Validate(request);

        if (!validator.IsValid){
            var errorMessage = validator.Errors.Select(error => error.ErrorMessage).ToList();
            throw new InvalidRequestException(errorMessage);
        }
    }

    public string GenerateVerificationCode(){
        string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        StringBuilder code = new StringBuilder();
        
        for (int i = 0; i < 6; i++)
        {
            int index = RandomNumberGenerator.GetInt32(characters.Length);
            code.Append(characters[index]);
        }

        return code.ToString();
    }
    
}