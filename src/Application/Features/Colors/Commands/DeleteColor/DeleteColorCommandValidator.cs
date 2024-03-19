using FluentValidation;

namespace Application.Features.Colors.Commands.DeleteColor;

public class DeleteColorCommandValidator : AbstractValidator<DeleteColorCommand>
{
    public DeleteColorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}
