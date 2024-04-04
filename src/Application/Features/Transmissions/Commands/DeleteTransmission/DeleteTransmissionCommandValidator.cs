using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.DeleteTransmission;

public class DeleteTransmissionCommandValidator : AbstractValidator<DeleteTransmissionCommand>
{
    public DeleteTransmissionCommandValidator()
    {
        RuleFor(t => t.Id).NotEmpty();
    }
}
