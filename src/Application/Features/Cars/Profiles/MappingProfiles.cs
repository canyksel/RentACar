using Application.Features.Cars.Commands.CreateCar;
using Application.Features.Cars.Commands.DeleteCar;
using Application.Features.Cars.Commands.UpdateCar;
using Application.Features.Cars.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Cars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Car, CreatedCarDto>().ReverseMap();
        CreateMap<Car,CreateCarCommand>().ReverseMap();
        CreateMap<Car, UpdatedCarDto>().ReverseMap();
        CreateMap<Car, UpdateCarCommand>().ReverseMap();
        CreateMap<Car, DeletedCarDto>().ReverseMap();
        CreateMap<Car, DeleteCarCommand>().ReverseMap();
    }
}
