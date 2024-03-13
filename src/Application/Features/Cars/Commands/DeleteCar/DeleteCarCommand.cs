using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.DeleteCar;

public class DeleteCarCommand : IRequest<DeletedCarDto>
{
    public int Id { get; set; }

    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeletedCarDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;

        public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<DeletedCarDto> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(c => c.Id == request.Id);

            _carBusinessRules.CarShouldExistsWhenRequested(car);

            Car mappedCar = _mapper.Map<Car>(request);
            Car deletedCar = await _carRepository.DeleteAsync(mappedCar);
            DeletedCarDto deletedCarDto = _mapper.Map<DeletedCarDto>(deletedCar);

            return deletedCarDto;
        }
    }
}
