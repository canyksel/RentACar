using Domain.Entities;


namespace Application.Features.Transmissions.Dtos;

public class TransmissionGetByIdDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Model> Models { get; set; }
}
