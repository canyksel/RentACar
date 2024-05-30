using Application.Features.Transmissions.Dtos;

namespace Application.Features.Transmissions.Models;

public class TransmissionModel
{
    public IList<TransmissionListDto> Items { get; set; }
}
