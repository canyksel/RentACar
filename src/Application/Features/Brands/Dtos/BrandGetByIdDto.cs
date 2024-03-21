using Application.Features.Models.Models;
using Core.Paging;

namespace Application.Features.Brands.Dtos;

public class BrandGetByIdDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
