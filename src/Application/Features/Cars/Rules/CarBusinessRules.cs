using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Cars.Rules;

public class CarBusinessRules
{
    private readonly ICarRepository _carRepository;

    public CarBusinessRules(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public void CarShouldExistsWhenRequested(Car car)
    {
        if (car is null) throw new BusinessException("Car does not exists.");
    }
}
