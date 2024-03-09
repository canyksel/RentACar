using Core.Repositories;

namespace Domain.Entities;

public class Model : Entity
{
    public int BrandId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }
    public virtual Brand? Brand { get; set; }

    public Model()
    {
        Name = string.Empty;
        ImageUrl = string.Empty;
    }

    public Model(int id, int brandId, string name, decimal dailyPrice, string ımageUrl) : this()
    {
        Id = id;
        BrandId = brandId;
        Name = name;
        DailyPrice = dailyPrice;
        ImageUrl = ımageUrl;
    }
}
