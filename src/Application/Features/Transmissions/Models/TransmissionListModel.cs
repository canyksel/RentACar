using Application.Features.Transmissions.Dtos;

namespace Application.Features.Transmissions.Models;

public class TransmissionListModel
{
    public IList<TransmissionListDto> Items { get; set; }
}
