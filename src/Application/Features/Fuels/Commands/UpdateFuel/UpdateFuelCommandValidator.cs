using FluentValidation;

namespace Application.Features.Fuels.Commands.UpdateFuel;

public class UpdateFuelCommandValidator : AbstractValidator<UpdateFuelCommand>
{
    public UpdateFuelCommandValidator()
    {
        RuleFor(f => f.Id).NotEmpty();
        RuleFor(f => f.Name).NotEmpty();
        RuleFor(f => f.Name).MinimumLength(2);
    }
}
