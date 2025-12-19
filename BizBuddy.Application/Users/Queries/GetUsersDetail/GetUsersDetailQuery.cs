using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Users.Queries.GetUsersDetail;

public record GetUsersDetailQuery(int Id) : IRequest<Result<UsersDto>>;
public class GetUsersDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetUsersDetailQuery, Result<UsersDto>>
{
    public async Task<Result<UsersDto>> Handle(GetUsersDetailQuery request, CancellationToken ct)
    {
        var entity = await context.User
            .AsQueryable()
            .ProjectTo<UsersDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<UsersDto>.Failure("Not found");

        return Result<UsersDto>.Success(entity);
    }
}
