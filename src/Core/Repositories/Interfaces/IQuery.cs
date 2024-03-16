namespace Core.Repositories.Interfaces;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
