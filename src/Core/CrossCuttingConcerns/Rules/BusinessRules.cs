using Core.CrossCuttingConcerns.Exceptions;
using Core.Paging;
using Core.Repositories.Interfaces;

namespace Core.CrossCuttingConcerns.Rules;

public abstract class BusinessRuleBase<T> : IBusinessRules<T> where T : IEntity
{
    private readonly IRepository<T> _repository;
    private readonly IAsyncRepository<T> _asyncRepository;

    protected BusinessRuleBase()
    {
        
    }

    protected BusinessRuleBase(IRepository<T> repository, IAsyncRepository<T> asyncRepository) : this()
    {
        _repository = repository;
        _asyncRepository = asyncRepository;
    }

    public async Task IsNameExists(string name)
    {
        IPaginate<T> result = await _asyncRepository.GetListAsync(x => x.GetType().Name  == name);
        if (result.Items.Any()) throw new BusinessException("Name exists.");
    }
}
