using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Account;

namespace BizBuddy.Application.Users.Queries.GetUserWithPagination;

public class UserListDto: IMapFrom<User>
{
    public int Id { get; set; }
    public string DisplayName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Phone { get; set; }
    public int RoleId { get; set; }
    public string RoleName { get; set; } = default!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserListDto>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
        
    }
}