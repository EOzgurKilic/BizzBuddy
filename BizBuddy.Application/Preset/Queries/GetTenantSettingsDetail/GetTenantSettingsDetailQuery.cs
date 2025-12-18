using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Preset.Queries.GetTenantSettingsDetail;

public record GetTenantSettingsDetailQuery(int Id) : IRequest<Result<TenantSettingsDetailDto>>;
public class GetTenantSettingsDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetTenantSettingsDetailQuery, Result<TenantSettingsDetailDto>>
{
    public async Task<Result<TenantSettingsDetailDto>> Handle(GetTenantSettingsDetailQuery request, CancellationToken ct)
    {
        var entity = await context.TenantSettings
            .AsQueryable()
            .ProjectTo<TenantSettingsDetailDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<TenantSettingsDetailDto>.Failure("TenantSettings not found.");

        return Result<TenantSettingsDetailDto>.Success(entity);
    }
}