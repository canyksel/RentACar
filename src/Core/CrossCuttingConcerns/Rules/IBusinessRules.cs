using Core.Repositories.Interfaces;

namespace Core.CrossCuttingConcerns.Rules;

public interface IBusinessRules<T> where T : IEntity
{
    Task IsNameExists(string name);
    void ShouldExistsWhenRequested(T entity);
}
