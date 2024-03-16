namespace Core.Repositories.Interfaces;

public interface IEntity
{
}
public interface IEntity<TKey> : IEntity
{
    TKey Id { get; }
}