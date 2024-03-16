using Core.Repositories.Interfaces;

namespace Core.Repositories;

public abstract class Entity<TKey> : IEntity<TKey>
{
    public virtual TKey Id { get; set; }

    public Entity()
    {
    }

    protected Entity(TKey id)
    {
        Id = id;
    }
}
