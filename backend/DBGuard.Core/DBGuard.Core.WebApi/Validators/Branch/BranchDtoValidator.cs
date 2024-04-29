using DBGuard.Core.Common.DTO.Branch;
using FluentValidation;

namespace DBGuard.Core.WebAPI.Validators.Branch;

public class BranchDtoValidator : AbstractValidator<BranchDto>
{
    public BranchDtoValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(200)
            .Matches(ValidationRegExes.BranchName);
    }
}