using Core.Repositories;

namespace Domain.Entities;

public class Brand : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; }

    public Brand()
    {
        Name = string.Empty;
    }

    public Brand(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}
