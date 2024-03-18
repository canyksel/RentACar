using Application.Features.Colors.Dtos;
using MediatR;

namespace Application.Features.Colors.Commands.CreateColor;

public class CreateColorCommand : IRequest<CreatedColorDto>
{
}
