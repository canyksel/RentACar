using Core.CrossCuttingConcerns.Exceptions;
using Core.Paging;
using Core.Repositories;
using Core.Repositories.Interfaces;

namespace Core.CrossCuttingConcerns.Rules;

public abstract class BusinessRules<T> : IBusinessRules<T> where T : IEntity
{
    private readonly IRepository<T> _repository;
    private readonly IAsyncRepository<T> _asyncRepository;

    protected BusinessRules()
    {
    }

    protected BusinessRules(IRepository<T> repository, IAsyncRepository<T> asyncRepository) : this()
    {
        _repository = repository;
        _asyncRepository = asyncRepository;
    }

    public async Task IsNameExists(string name)
    {
        IPaginate<T> result = await _asyncRepository.GetListAsync(predicate: x => x.GetType().GetProperty("Name").GetValue(x).Equals(name));
        if (result.Items.Any()) throw new BusinessException("Name exists.");
    }

    public void ShouldExistsWhenRequested(T entity)
    {
        if (entity is null) throw new BusinessException("Item does not exists.");
    }
}
