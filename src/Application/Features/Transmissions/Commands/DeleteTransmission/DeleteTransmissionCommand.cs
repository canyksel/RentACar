using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Transmissions.Commands.DeleteTransmission;

public class DeleteTransmissionCommand : IRequest<DeletedTransmissionDto>
{
    public int Id { get; set; }

    public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, DeletedTransmissionDto>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;
        private readonly TransmissionBusinessRules _transmissionBusinessRules;

        public DeleteTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper, TransmissionBusinessRules transmissionBusinessRules)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
            _transmissionBusinessRules = transmissionBusinessRules;
        }

        public async Task<DeletedTransmissionDto> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
        {
            Transmission? transmission = await _transmissionRepository.GetAsync(t => t.Id == request.Id);

            await _transmissionBusinessRules.TransmissionIdShouldExistWhenSelected(request.Id);

            Transmission mappedTransmission = _mapper.Map<Transmission>(request);
            Transmission deletedTransmission = await _transmissionRepository.DeleteAsync(mappedTransmission);
            DeletedTransmissionDto deletedTransmissionDto = _mapper.Map<DeletedTransmissionDto>(deletedTransmission);

            return deletedTransmissionDto;
        }
    }
}
