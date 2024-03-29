using FluentValidation;

namespace Application.Features.Fuels.Commands.CreateFuel;

public class CreateFuelCommandValidator : AbstractValidator<CreateFuelCommand>
{
    public CreateFuelCommandValidator()
    {
        RuleFor(f => f.Name).NotEmpty();
        RuleFor(f => f.Name).MinimumLength(2);
    }
}
