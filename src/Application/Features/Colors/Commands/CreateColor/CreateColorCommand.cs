using Application.Features.Colors.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Commands.CreateColor;

public class CreateColorCommand : IRequest<CreatedColorDto>
{
}
