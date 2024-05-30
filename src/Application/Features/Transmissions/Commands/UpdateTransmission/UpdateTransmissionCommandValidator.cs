using FluentValidation;

namespace Application.Features.Transmissions.Commands.UpdateTransmission;

public class UpdateTransmissionCommandValidator : AbstractValidator<UpdateTransmissionCommand>
{
    public UpdateTransmissionCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty();
        RuleFor(t => t.Name).NotEmpty();
        RuleFor(t => t.Name).MaximumLength(2);
    }
}
