using Application.Features.Brands.Dtos.Brands;
using MediatR;

namespace Application.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommand : IRequest<DeletedBrandDto>
{
    public int Id { get; set; }
    public bool? IsMultiple { get; set; }
    public int[]? Ids { get; set; }
}

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandDto>
{
    public Task<DeletedBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
