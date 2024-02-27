using FluentValidation;

namespace Application.Features.Models.Commands.DeleteModel;

public class DeleteModelCommandValidator : AbstractValidator<DeleteModelCommand>
{
    public DeleteModelCommandValidator()
    {
        RuleFor(m => m.Id).NotEmpty();
    }
}
