﻿using Core.Repositories;

namespace Domain.Entities;

public class Color : Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<Car> Cars { get; set; }

    public Color()
    {
        Cars = new HashSet<Car>();
    }

    public Color(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}
