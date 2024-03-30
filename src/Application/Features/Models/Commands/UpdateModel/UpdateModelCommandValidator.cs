using FluentValidation;

namespace Application.Features.Models.Commands.UpdateModel;

public class UpdateModelCommandValidator : AbstractValidator<UpdateModelCommand>
{
    public UpdateModelCommandValidator()
    {
        RuleFor(m => m.Id).NotEmpty();
        RuleFor(m => m.Name).NotEmpty();
        RuleFor(m => m.Name).MinimumLength(2);
        RuleFor(m => m.BrandId).NotEmpty();
        RuleFor(m => m.FuelId).NotEmpty();
        RuleFor(m => m.DailyPrice).GreaterThan(0);
    }
}
