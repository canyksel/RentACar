using Application.Features.Colors.Commands.CreateColor;
using Application.Features.Colors.Commands.DeleteColor;
using Application.Features.Colors.Commands.UpdateColor;
using Application.Features.Colors.Dtos;
using Application.Features.Colors.Models;
using AutoMapper;
using Core.Paging;
using Domain.Entities;

namespace Application.Features.Colors.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Color, CreatedColorDto>().ReverseMap();
            CreateMap<Color, CreateColorCommand>().ReverseMap();
            CreateMap<Color, UpdatedColorDto>().ReverseMap();
            CreateMap<Color, UpdateColorCommand>().ReverseMap();
            CreateMap<Color, DeletedColorDto>().ReverseMap();
            CreateMap<Color, DeleteColorCommand>().ReverseMap();

            CreateMap<IPaginate<Color>, ColorListModel>().ReverseMap();
            CreateMap<Color, ColorListDto>().ReverseMap();
            CreateMap<Color, ColorGetByIdDto>().ReverseMap();
        }
    }
}
