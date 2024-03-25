using Core.Repositories;

namespace Domain.Entities;

public class Fuel : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; }
    public Fuel()
    {
        Name = string.Empty;
        Models = new HashSet<Model>();
    }

    public Fuel(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}
