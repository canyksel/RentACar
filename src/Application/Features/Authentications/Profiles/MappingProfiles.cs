using Application.Features.Authentications.Dtos;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Authentications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RefreshToken, RefreshTokenDto>().ReverseMap();
    }
}
