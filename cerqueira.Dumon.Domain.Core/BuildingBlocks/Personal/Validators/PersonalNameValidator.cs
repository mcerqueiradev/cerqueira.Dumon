using FluentValidation;

namespace cerqueira.Dumon.Domain.Core.BuildingBlocks.Personal.Validators;

public class PersonalNameValidator : AbstractValidator<PersonalName>
{
    public PersonalNameValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty").WithPropertyName(nameof(PersonalName.FirstName))
            .MinimumLength(2).WithMessage("First name must be at least 2 characters").WithPropertyName(nameof(PersonalName.FirstName))
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters").WithPropertyName(nameof(PersonalName.FirstName))
            .Matches(@"^[a-zA-Zà-üÀ-Ü\s\-']+$").WithMessage("First name contains invalid characters").WithPropertyName(nameof(PersonalName.FirstName));

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name cannot be empty").WithPropertyName(nameof(PersonalName.LastName))
            .MinimumLength(2).WithMessage("Last name must be at least 2 characters").WithPropertyName(nameof(PersonalName.LastName))
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters").WithPropertyName(nameof(PersonalName.LastName))
            .Matches(@"^[a-zA-Zà-üÀ-Ü\s\-']+$").WithMessage("Last name contains invalid characters").WithPropertyName(nameof(PersonalName.LastName));
    }
}