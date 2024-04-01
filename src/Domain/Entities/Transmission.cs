using Core.Repositories;

namespace Domain.Entities;

public class Transmission : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; }

    public Transmission()
    {
        Name = string.Empty;
        Models = new HashSet<Model>();
    }

    public Transmission(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}
