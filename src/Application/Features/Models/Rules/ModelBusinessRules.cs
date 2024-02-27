using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.Models.Rules;

public class ModelBusinessRules
{
    private readonly IModelRepository _modelRepository;

    public ModelBusinessRules(IModelRepository modelRepository)
    {
        _modelRepository = modelRepository;
    }

    public void ModelShouldExistsWhenRequested(Model model)
    {
        if (model is null) throw new BusinessException("Model does not exists.");
    }
    public async Task ModelNameWithSameBrandCanNotBeDuplicatedWhenUpdated(int id, string name, int brandId)
    {
        Model? result = await _modelRepository.GetAsync(m => m.Id == id && m.Name.Equals(name) && m.BrandId == brandId);
        if (result is not null) throw new BusinessException("Model already exists.");
    }
}
