using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Tenat.Queries.GetTenantDetail;

public record GetTenantDetailQuery(int Id) : IRequest<Result<TenantDto>>;
public class GetTenantDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetTenantDetailQuery, Result<TenantDto>>
{
    public async Task<Result<TenantDto>> Handle(GetTenantDetailQuery request, CancellationToken ct)
    {
        var entity = await context.Tenat
            .AsQueryable()
            .ProjectTo<TenantDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<TenantDto>.Failure("Not found");

        return Result<TenantDto>.Success(entity);
    }
}
