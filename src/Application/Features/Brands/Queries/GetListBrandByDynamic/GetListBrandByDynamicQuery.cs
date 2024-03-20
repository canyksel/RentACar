using Application.Features.Brands.Models;
using Application.Requests;
using Application.Services.Repositories;
using AutoMapper;
using Core.Dynamic;
using Core.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetListBrandByDynamic;

public class GetListBrandByDynamicQuery : IRequest<BrandListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }
    public class GetListBrandByDynamicQueryHandler : IRequestHandler<GetListBrandByDynamicQuery, BrandListModel>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetListBrandByDynamicQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<BrandListModel> Handle(GetListBrandByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Brand> brands = await _brandRepository
                .GetListByDynamicAsync(request.Dynamic,
                                       index: request.PageRequest.Page,
                                       size: request.PageRequest.PageSize);

            BrandListModel mappedBrands = _mapper.Map<BrandListModel>(brands);
            return mappedBrands;
        }
    }
}
