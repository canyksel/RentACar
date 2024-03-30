using FluentValidation;

namespace Application.Features.Models.Commands.CreateModel;

public class CreateModelCommandValidator : AbstractValidator<CreateModelCommand>
{
    public CreateModelCommandValidator()
    {
        RuleFor(m => m.Name).NotEmpty();
        RuleFor(m => m.Name).MinimumLength(2);
        RuleFor(m => m.BrandId).NotEmpty();
        RuleFor(m => m.FuelId).NotEmpty();
        RuleFor(m => m.DailyPrice).GreaterThan(0);
    }
}
