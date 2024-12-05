using Core.Repositories;
using System.Collections.Generic;

namespace Domain.Entities;

public class Brand : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; }

    public Brand()
    {
        Name = string.Empty;
        Models = new HashSet<Model>();
    }

    public Brand(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}
