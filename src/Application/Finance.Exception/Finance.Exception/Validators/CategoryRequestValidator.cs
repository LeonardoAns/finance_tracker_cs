using Finance.Communication.Category.Request;
using FluentValidation;

namespace Finance.Exception.Validators;

public class CategoryRequestValidator : AbstractValidator<CategoryRequestJson> {
    
    public CategoryRequestValidator(){
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty or null");

        RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage("Name cannot be empty or null");
    }
}