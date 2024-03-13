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
    public int ModelId { get; set; }
    public CarState CarState { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }

    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdatedCarDto>
    {
        private ICarRepository CarRepository { get; }
        private IMapper Mapper { get; }
        private CarBusinessRules CarBusinessRules { get; }
        public async Task<UpdatedCarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            Car? car = await CarRepository.GetAsync(c => c.Id == request.Id);

            CarBusinessRules.CarShouldExistsWhenRequested(car);

            Car mappedCar = Mapper.Map<Car>(request);
            Car updatedCar = await CarRepository.UpdateAsync(mappedCar);
            UpdatedCarDto updatedCarDto = Mapper.Map<UpdatedCarDto>(updatedCar);

            return updatedCarDto;

        }
    }
}
