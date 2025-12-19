using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.RoleAssignment.Queries.GetBrandingDetail;


public record GetBrandingDetailQuery(int Id) : IRequest<Result<BrandingDto>>;
public class GetBrandingDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetBrandingDetailQuery, Result<BrandingDto>>
{
    public async Task<Result<BrandingDto>> Handle(GetBrandingDetailQuery request, CancellationToken ct)
    {
        var entity = await context.Branding
            .AsQueryable()
            .ProjectTo<BrandingDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<BrandingDto>.Failure("Branding Not found");

        return Result<BrandingDto>.Success(entity);
    }
}
