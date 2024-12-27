using Domain.Enums;
using Finance.Communication.Expense.Request;
using FluentValidation;
using FluentValidation.Validators;

namespace Finance.Exception.Validators;

public class ExpenseRequestValidator : AbstractValidator<ExpenseRequestJson> {
    
    public ExpenseRequestValidator(){
        RuleFor(e => e.Description)
            .NotEmpty()
            .WithMessage("Description cannot be empty or null");

        RuleFor(e => e.Value)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Value Must be Greater Than 0");

        RuleFor(e => e.PaymentMethod)
            .Must(BeAValidPaymentMethod)
            .WithMessage("Invalid Payment method");

        RuleFor(e => e.CategoryId)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Category Id Must be Greater Than 0");
    }
    
    private bool BeAValidPaymentMethod(PaymentMethod paymentMethod) {
        return Enum.IsDefined(typeof(PaymentMethod), paymentMethod);
    }
}