using Application.Features.Fuels.Dtos;

namespace Application.Features.Fuels.Models;

public class FuelListModel
{
    public IList<FuelListDto> Items { get; set; }
}
