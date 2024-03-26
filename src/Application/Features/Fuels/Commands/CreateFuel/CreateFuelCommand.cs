using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Commands.CreateFuel;

public class CreateFuelCommand : IRequest<CreatedFuelDto>
{
    public string Name { get; set; }

    public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, CreatedFuelDto>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;
        private readonly FuelBusinessRules _fuelBusinessRules;

        public CreateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusinessRules fuelBusinessRules)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
            _fuelBusinessRules = fuelBusinessRules;
        }

        public async Task<CreatedFuelDto> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
        {
            //Business
            await _fuelBusinessRules.FuelNameCannotBeDuplicatedWhenInserted(request.Name);

            //Repository
            Fuel? mappedFuel = _mapper.Map<Fuel>(request);
            Fuel createdFuel = await _fuelRepository.AddAsync(mappedFuel);
            CreatedFuelDto createdFuelDto = _mapper.Map<CreatedFuelDto>(createdFuel);

            //Return
            return createdFuelDto;
        }
    }
}
