using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.CrossCuttingConcerns.Rules;
using Core.Paging;
using Core.Repositories.Interfaces;
using Domain.Entities;

namespace Application.Features.Transmissions.Rules;

public class TransmissionBusinessRules: BusinessRules<Transmission> 
{
    private readonly ITransmissionRepository _transmissionRepository;

    public TransmissionBusinessRules(ITransmissionRepository transmissionRepository)
    {
        _transmissionRepository = transmissionRepository;
    }
    public async Task TransmissionIdShouldExistWhenSelected(int id)
    {
        Transmission? result = await _transmissionRepository.GetAsync(predicate: b => b.Id == id, enableTracking: false);
        if (result == null)
            throw new BusinessException("Transmission not found.");
    }
    public async Task TransmissionNameCannotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<Transmission> result = await _transmissionRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException("Transmission name exists.");
    }
}
