using DBGuard.Core.Common.DTO.Commit;
using FluentValidation;

namespace DBGuard.Core.WebAPI.Validators.Commit;

public class CreateCommitDtoValidator: AbstractValidator<CreateCommitDto>
{
    public CreateCommitDtoValidator()
    {
        RuleFor(x => x.Message)
            .NotEmpty()
            .MaximumLength(300);

        RuleFor(x => x.ChangesGuid)
            .NotEmpty();

        RuleFor(x => x.SelectedItems)
            .Must(x => x.Any(x=> x.Children.Any(y => y.Selected)));
    }
}
