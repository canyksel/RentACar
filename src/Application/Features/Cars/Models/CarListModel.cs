using Application.Features.Cars.Dtos;

namespace Application.Features.Cars.Models;

public class CarListModel
{
    public IList<CarListDto> Items { get; set; }
}
