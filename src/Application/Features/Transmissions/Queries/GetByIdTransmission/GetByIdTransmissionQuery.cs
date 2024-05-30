using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Transmissions.Queries.GetByIdTransmission;

public class GetByIdTransmissionQuery : IRequest<TransmissionGetByIdDto>
{
    public int Id { get; set; }

    public class GetByIdTransmissionQueryHandler : IRequestHandler<GetByIdTransmissionQuery, TransmissionGetByIdDto>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;
        private readonly TransmissionBusinessRules _transmissionBusinessRules;

        public GetByIdTransmissionQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper, TransmissionBusinessRules transmissionBusinessRules)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
            _transmissionBusinessRules = transmissionBusinessRules;
        }

        public async Task<TransmissionGetByIdDto> Handle(GetByIdTransmissionQuery request, CancellationToken cancellationToken)
        {
            Transmission? transmission = await _transmissionRepository.GetAsync(t => t.Id == request.Id,
                                                                                include: t => t.Include(t => t.Models));

            _transmissionBusinessRules.ShouldExistsWhenRequested(transmission);

            TransmissionGetByIdDto transmissionGetByIdDto = _mapper.Map<TransmissionGetByIdDto>(transmission);
            return transmissionGetByIdDto;
        }
    }
}
