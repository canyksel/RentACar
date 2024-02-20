using Application.Features.Brands.Dtos.Brands;
using Application.Features.Brands.Rules.Brands;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.UpdateBrand;

public class UpdateBrandCommand : IRequest<UpdatedBrandDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandDto>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly BrandBusinessRules _brandBusinessRules;

    public UpdateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<UpdatedBrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {

        Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.Id);

        await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenUpdated(request.Id, request.Name);

        Brand mappedBrand = _mapper.Map<Brand>(request);
        Brand updatedBrand = await _brandRepository.UpdateAsync(mappedBrand);
        UpdatedBrandDto updatedBrandDto = _mapper.Map<UpdatedBrandDto>(updatedBrand);

        return updatedBrandDto;
    }
}
