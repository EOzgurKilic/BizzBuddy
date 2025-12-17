using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.CustomFieldDefs.Queries.GetCustomFieldDefsDetail;

public record GetCustomFieldDefsDetailQuery(int Id) : IRequest<Result<CustomFieldDefsDetailDto>>;
public class GetCustomFieldDefsDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetCustomFieldDefsDetailQuery, Result<CustomFieldDefsDetailDto>>
{
    public async Task<Result<CustomFieldDefsDetailDto>> Handle(GetCustomFieldDefsDetailQuery request, CancellationToken ct)
    {
        var entity = await context.CustomFieldDef
            .AsQueryable()
            .ProjectTo<CustomFieldDefsDetailDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<CustomFieldDefsDetailDto>.Failure("CustomFieldDef not found.");

        return Result<CustomFieldDefsDetailDto>.Success(entity);
    }
}
