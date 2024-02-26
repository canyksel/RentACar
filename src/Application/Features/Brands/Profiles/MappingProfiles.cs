using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreatedBrandDto>().ReverseMap();
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, UpdatedBrandDto>().ReverseMap();
        CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
        CreateMap<Brand, DeletedBrandDto>().ReverseMap();
        CreateMap<Brand, DeleteBrandCommand>().ReverseMap();

        CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
        CreateMap<Brand, BrandListDto>().ReverseMap();
        CreateMap<Brand, BrandGetByIdDto>().ReverseMap();
    }
}
