using Application.Features.Colors.Dtos;

namespace Application.Features.Colors.Models;

public class ColorListModel
{
    public IList<ColorListDto> Items { get; set; }
}
