using DBGuard.Core.Common.DTO.Branch;
using FluentValidation;

namespace DBGuard.Core.WebAPI.Validators.Branch;

public class MergeBranchDtoValidator: AbstractValidator<MergeBranchDto>
{
    public MergeBranchDtoValidator()
    {
        RuleFor(x => x.SourceId)
            .NotEqual(x => x.DestinationId);
    }
}
