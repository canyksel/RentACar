using FluentValidation;

namespace Application.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
{
    public DeleteBrandCommandValidator()
    {
        RuleFor(b => b.Id).NotEmpty();
    }
}
