using AutoMapper;
using TestIdentity.Application.DTOs.Role;
using TestIdentity.Domain.Entities;

namespace TestIdentity.Application.Mappings.RoleMapping;
public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));
    }
}
