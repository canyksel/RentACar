using Application.Features.Transmissions.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Transmissions.Profiles;

public class TransmissionProfiles : Profile
{
    public TransmissionProfiles()
    {
        CreateMap<Transmission, CreatedTransmissionDto>().ReverseMap();
        CreateMap<Transmission, UpdatedTransmissionDto>().ReverseMap();
        CreateMap<Transmission, DeletedTransmissionDto>().ReverseMap();
    }
}
