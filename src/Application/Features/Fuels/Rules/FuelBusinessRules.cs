using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Paging;
using Domain.Entities;

namespace Application.Features.Fuels.Rules;

public class FuelBusinessRules
{
    private readonly IFuelRepository _fuelRepository;

    public FuelBusinessRules(IFuelRepository fuelRepository)
    {
        _fuelRepository = fuelRepository;
    }

    public async Task FuelNameCannotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<Fuel> result = await _fuelRepository.GetListAsync(f => f.Name == name);
        if (result.Items.Any()) throw new BusinessException("Fuel name exists.");
    }
    public void FuelShouldExistsWhenRequested(Fuel fuel)
    {
        if (fuel is null) throw new BusinessException("Fuel does not exists.");
    }
}
