using Core.Repositories;

namespace Domain.Entities;

public class Model : Entity<int>
{
    public int BrandId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }

    public virtual Brand? Brand { get; set; }
    public virtual ICollection<Car> Cars { get; set; }

    public Model()
    {
        Name = string.Empty;
        ImageUrl = string.Empty;
        Cars = new HashSet<Car>();
    }

    public Model(int id, int brandId, string name, decimal dailyPrice, string imageUrl) : this()
    {
        Id = id;
        BrandId = brandId;
        Name = name;
        DailyPrice = dailyPrice;
        ImageUrl = imageUrl;
    }
}
