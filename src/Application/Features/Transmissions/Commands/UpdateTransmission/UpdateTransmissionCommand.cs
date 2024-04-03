using Application.Features.Transmissions.Dtos;
using MediatR;

namespace Application.Features.Transmissions.Commands.UpdateTransmission;

public class UpdateTransmissionCommand : IRequest<UpdatedTransmissionDto>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, UpdatedTransmissionDto>
    {
        public Task<UpdatedTransmissionDto> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
