using FluentValidation;

namespace Application.Features.Transmissions.Commands.CreateTransmission;

public class CreateTransmissionCommandValidator : AbstractValidator<CreateTransmissionCommand>
{
    public CreateTransmissionCommandValidator()
    {
        RuleFor(t => t.Name).NotEmpty();
        RuleFor(t => t.Name).MaximumLength(2);
    }
}
