using FluentValidation;

namespace Application.Features.Transmissions.Commands.DeleteTransmission;

public class DeleteTransmissionCommandValidator : AbstractValidator<DeleteTransmissionCommand>
{
    public DeleteTransmissionCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty();
    }
}
