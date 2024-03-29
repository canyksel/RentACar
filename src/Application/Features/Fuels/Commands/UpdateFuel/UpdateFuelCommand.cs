using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Commands.UpdateFuel;

public class UpdateFuelCommand : IRequest<UpdatedFuelDto>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, UpdatedFuelDto>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;
        private readonly FuelBusinessRules _fuelBusinessRules;

        public UpdateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusinessRules fuelBusinessRules)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
            _fuelBusinessRules = fuelBusinessRules;
        }

        public async Task<UpdatedFuelDto> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
        {
            Fuel? fuel = await _fuelRepository.GetAsync(f => f.Id == request.Id);

            _fuelBusinessRules.FuelShouldExistsWhenRequested(fuel);

            Fuel mappedFuel = _mapper.Map<Fuel>(fuel);
            Fuel updatedFuel = await _fuelRepository.UpdateAsync(fuel);
            UpdatedFuelDto updatedFuelDto = _mapper.Map<UpdatedFuelDto>(updatedFuel);

            return updatedFuelDto;
        }
    }
}
