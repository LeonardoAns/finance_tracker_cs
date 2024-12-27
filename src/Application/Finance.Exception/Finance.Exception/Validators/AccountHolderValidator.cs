using Finance.Communication.AccountHolder.Request;
using FluentValidation;

namespace Finance.Exception.Validators;

public class AccountHolderValidator : AbstractValidator<AccountHolderRequestJson> {
    
    public AccountHolderValidator(){
        RuleFor(a => a.FullName)
            .NotEmpty()
            .WithMessage("Full Name Cannot be Empty");

        RuleFor(a => a.Email)
            .NotEmpty()
            .WithMessage("Email Cannot be Empty");
        
        RuleFor(a => a.Password)
            .NotEmpty()
            .WithMessage("Password Cannot be Empty");
    }
}