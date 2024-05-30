using Domain.Entities;

namespace Application.Features.Transmissions.Dtos;

public class TransmissionListDto
{
    public string Name { get; set; }
    public IEnumerable<Model> models { get; set; }
}
