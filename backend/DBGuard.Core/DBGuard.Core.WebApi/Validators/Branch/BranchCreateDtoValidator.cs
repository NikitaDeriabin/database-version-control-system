using DBGuard.Core.Common.DTO.Branch;
using FluentValidation;

namespace DBGuard.Core.WebAPI.Validators.Branch;

public class BranchCreateDtoValidator : AbstractValidator<BranchCreateDto>
{
    public BranchCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(200)
            .Matches(ValidationRegExes.BranchName);
    }
}
