using Core.CrossCuttingConcerns.Exceptions;
using Core.Paging;
using Core.Repositories.Interfaces;

namespace Core.CrossCuttingConcerns.Rules;

public abstract class BusinessRules<TEntity> : IBusinessRules<TEntity> where TEntity : IEntity
{
    private readonly IRepository<TEntity> _repository;
    private readonly IAsyncRepository<TEntity> _asyncRepository;

    protected BusinessRules()
    {
    }

    protected BusinessRules(IRepository<TEntity> repository, IAsyncRepository<TEntity> asyncRepository) : this()
    {
        _repository = repository;
        _asyncRepository = asyncRepository;
    }

    public async Task IsNameExists(string name)
    {
        IPaginate<TEntity> result = await _asyncRepository.GetListAsync(predicate: x => x.GetType().GetProperty("Name").GetValue(x).Equals(name));
        if (result.Items.Any()) throw new BusinessException("Name exists.");
    }

    public void ShouldExistsWhenRequested(TEntity entity)
    {
        if (entity is null) throw new BusinessException($"{typeof(TEntity)?.Name} does not exists.");
    }
}
