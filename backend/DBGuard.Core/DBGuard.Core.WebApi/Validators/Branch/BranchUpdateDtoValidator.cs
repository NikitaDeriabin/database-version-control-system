using DBGuard.Core.Common.DTO.Branch;
using FluentValidation;

namespace DBGuard.Core.WebAPI.Validators.Branch;

public class BranchUpdateDtoValidator : AbstractValidator<BranchUpdateDto>
{
    public BranchUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(200)
            .Matches(ValidationRegExes.BranchName);
    }
}