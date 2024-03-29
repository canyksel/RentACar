using Application.Features.Fuels.Commands.CreateFuel;
using Application.Features.Fuels.Commands.DeleteFuel;
using Application.Features.Fuels.Commands.UpdateFuel;
using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Models;
using Application.Features.Fuels.Queries.GetByIdFuel;
using AutoMapper;
using Core.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Fuel, CreateFuelCommand>().ReverseMap();
        CreateMap<Fuel, CreatedFuelDto>().ReverseMap();
        CreateMap<Fuel, UpdateFuelCommand>().ReverseMap();
        CreateMap<Fuel, UpdatedFuelDto>().ReverseMap();
        CreateMap<Fuel, DeleteFuelCommand>().ReverseMap();
        CreateMap<Fuel, DeletedFuelDto>().ReverseMap();

        CreateMap<IPaginate<Fuel>, FuelListModel>().ReverseMap();
        CreateMap<Fuel, FuelGetByIdDto>().ReverseMap();
        CreateMap<Fuel, FuelListDto>().ReverseMap();
    }
}
