using Application.Features.Models.Commands.CreateModel;
using Application.Features.Models.Commands.DeleteModel;
using Application.Features.Models.Commands.UpdateModel;
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
        CreateMap<Model, CreatedModelDto>().ReverseMap();
        CreateMap<Model, CreateModelCommand>().ReverseMap();
        CreateMap<Model, UpdatedModelDto>().ReverseMap();
        CreateMap<Model, UpdateModelCommand>().ReverseMap();
        CreateMap<Model, DeletedModelDto>().ReverseMap();
        CreateMap<Model, DeleteModelCommand>().ReverseMap();

        CreateMap<Model, ModelListDto>()
            .ForMember(dest => dest.BrandName, src => src.MapFrom(c => c.Brand.Name))
            .ReverseMap();
        CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();

        CreateMap<Model, ModelGetByIdDto>()
            .ForMember(dest => dest.BrandName, src => src.MapFrom(c => c.Brand.Name))
            .ReverseMap();
    }
}
