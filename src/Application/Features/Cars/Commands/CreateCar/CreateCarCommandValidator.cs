using FluentValidation;

namespace Application.Features.Cars.Commands.CreateCar;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(c=>c.ModelId).NotEmpty();
        RuleFor(c=> c.CarState).NotEmpty();
        RuleFor(c=>c.Kilometer).NotEmpty();
        RuleFor(c => c.ModelYear).NotEmpty();
        RuleFor(c=>c.Plate).NotEmpty();
    }
}
