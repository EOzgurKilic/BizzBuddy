using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.RoleAssignment;

namespace BizBuddy.Application.RoleAssignment.Queries.GetRoleDetail;

public class RoleDto: IMapFrom<Role>
{
public int Id { get; set; }
    public string RoleName { get; set; } = default!;
    public string? Description { get; set; }

    public int UserCount { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Role, RoleDto>()
            .ForMember(dest => dest.UserCount, opt => opt.MapFrom(src => src.Users.Count));
    }
}
