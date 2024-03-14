using FluentValidation;

namespace Application.Features.Cars.Commands.DeleteCar;

public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
{
    public DeleteCarCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
