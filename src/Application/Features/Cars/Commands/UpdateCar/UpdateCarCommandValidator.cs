using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarCommandValidator()
        {
            RuleFor(c=>c.Id).NotEmpty();
            RuleFor(c => c.ModelId).NotEmpty();
            RuleFor(c => c.CarState).NotEmpty();
            RuleFor(c => c.Kilometer).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.Plate).NotEmpty();    //TODO : Custom validation rules must be add!
        }
    }
}
