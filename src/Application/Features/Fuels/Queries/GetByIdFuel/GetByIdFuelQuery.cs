using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Queries.GetByIdFuel;

public class GetByIdFuelQuery : IRequest<FuelGetByIdDto>
{
    public int Id { get; set; }

    public class GetByIdFuelQueryHandler : IRequestHandler<GetByIdFuelQuery, FuelGetByIdDto>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;
        private readonly FuelBusinessRules _fuelBusinessRules;

        public GetByIdFuelQueryHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusinessRules fuelBusinessRules)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
            _fuelBusinessRules = fuelBusinessRules;
        }

        public async Task<FuelGetByIdDto> Handle(GetByIdFuelQuery request, CancellationToken cancellationToken)
        {
            Fuel? fuel = await _fuelRepository.GetAsync(f => f.Id == request.Id);

            _fuelBusinessRules.FuelShouldExistsWhenRequested(fuel);

            FuelGetByIdDto fuelGetByIdDto = _mapper.Map<FuelGetByIdDto>(fuel);
            return fuelGetByIdDto;
        }
    }
}
