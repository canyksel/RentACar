using FluentValidation;

namespace Application.Features.Fuels.Commands.DeleteFuel;

public class DeleteFuelCommandValidator : AbstractValidator<DeleteFuelCommand>
{
    public DeleteFuelCommandValidator()
    {
        RuleFor(f => f.Id).NotEmpty();
    }
}
