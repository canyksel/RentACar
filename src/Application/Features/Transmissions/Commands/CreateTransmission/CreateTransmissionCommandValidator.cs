using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.CreateTransmission;

public class CreateTransmissionCommandValidator : AbstractValidator<CreateTransmissionCommand>
{
    public CreateTransmissionCommandValidator()
    {
        RuleFor(t => t.Name).NotEmpty();
        RuleFor(t => t.Name).MaximumLength(2);
    }
}
