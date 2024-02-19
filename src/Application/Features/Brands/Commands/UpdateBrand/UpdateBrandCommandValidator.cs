using FluentValidation;

namespace Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(b => b.Id).NotEmpty();
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
