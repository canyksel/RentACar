namespace Core.Repositories;

public abstract class Entity
{
    public int Id { get; set; }

    public Entity()
    {
    }

    protected Entity(int ıd) : this()
    {
        Id = ıd;
    }
}
