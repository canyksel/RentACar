using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Cars.Commands.UpdateCar;

public class UpdateCarCommand : IRequest<UpdatedCarDto>
{
    public int Id { get; set; }
    public int ColorId { get; set; }
    public int ModelId { get; set; }
    public CarState CarState { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }

    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdatedCarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;

        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<UpdatedCarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(c => c.Id == request.Id);

            _carBusinessRules.CarShouldExistsWhenRequested(car);

            Car mappedCar = _mapper.Map<Car>(request);
            Car updatedCar = await _carRepository.UpdateAsync(mappedCar);
            UpdatedCarDto updatedCarDto = _mapper.Map<UpdatedCarDto>(updatedCar);

            return updatedCarDto;

        }
    }
}
