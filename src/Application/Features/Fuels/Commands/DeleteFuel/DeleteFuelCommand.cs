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

namespace Application.Features.Fuels.Commands.DeleteFuel
{
    public class DeleteFuelCommand : IRequest<DeletedFuelDto>
    {
        public int Id { get; set; }

        public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, DeletedFuelDto>
        {
            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;
            private readonly FuelBusinessRules _fuelBusinessRules;

            public DeleteFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusinessRules fuelBusinessRules)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
                _fuelBusinessRules = fuelBusinessRules;
            }

            public async Task<DeletedFuelDto> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
            {
                Fuel? fuel = await _fuelRepository.GetAsync(f => f.Id == request.Id);

                _fuelBusinessRules.FuelShouldExistsWhenRequested(fuel);

                Fuel mappedFuel = _mapper.Map<Fuel>(fuel);
                Fuel deletedFuel = await _fuelRepository.DeleteAsync(mappedFuel);
                DeletedFuelDto deletedFuelDto = _mapper.Map<DeletedFuelDto>(deletedFuel);

                return deletedFuelDto;
            }
        }
    }
}
