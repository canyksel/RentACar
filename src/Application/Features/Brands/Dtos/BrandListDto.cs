using Application.Features.Models.Dtos;

namespace Application.Features.Brands.Dtos;

public class BrandListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<ModelListDto> Models { get; set; }
}
