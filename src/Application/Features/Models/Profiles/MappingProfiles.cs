using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreatedModelDto>().ReverseMap();
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();

        CreateMap<Model, ModelListDto>()
            .ForMember(dest => dest.BrandName, src => src.MapFrom(c => c.Brand.Name))
            .ReverseMap();
        CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();

        CreateMap<Model, ModelGetByIdDto>()
            .ForMember(dest => dest.BrandName, src => src.MapFrom(c => c.Brand.Name))
            .ReverseMap();
    }
}
