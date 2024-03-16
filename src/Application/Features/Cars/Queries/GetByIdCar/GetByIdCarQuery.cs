using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries.GetByIdCar;

public class GetByIdCarQuery : IRequest<CarGetByIdDto>
{
    public int Id { get; set; }
    public class GetByIdQueryHandler : IRequestHandler<GetByIdCarQuery, CarGetByIdDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;

        public GetByIdQueryHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<CarGetByIdDto> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(c => c.Id == request.Id);

            _carBusinessRules.CarShouldExistsWhenRequested(car);

            CarGetByIdDto carGetByIdDto = _mapper.Map<CarGetByIdDto>(car);
            return carGetByIdDto;
        }
    }
}
