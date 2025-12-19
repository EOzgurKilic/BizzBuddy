using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.RoleAssignment.Queries.GetRoleDetail;



public record GetRoleDetailQuery(int Id) : IRequest<Result<RoleDto>>;
public class GetRoleDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetRoleDetailQuery, Result<RoleDto>>
{
    public async Task<Result<RoleDto>> Handle(GetRoleDetailQuery request, CancellationToken ct)
    {
        var entity = await context.Role
            .AsQueryable()
            .ProjectTo<RoleDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<RoleDto>.Failure("Role Not found");

        return Result<RoleDto>.Success(entity);
    }
}