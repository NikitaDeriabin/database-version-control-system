using DBGuard.ConsoleApp.Models;
using FluentValidation;

namespace DBGuard.ConsoleApp.BL.Validators;

public class ConnectionStringDtoValidator : AbstractValidator<ConnectionStringDto>
{
    public ConnectionStringDtoValidator()
    {
        RuleFor(u => u.DbEngine).IsInEnum();
    }
}