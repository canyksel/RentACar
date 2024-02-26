using Application.Services.Repositories;

namespace Application.Features.Models.Rules;

public class ModelBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public ModelBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

}
