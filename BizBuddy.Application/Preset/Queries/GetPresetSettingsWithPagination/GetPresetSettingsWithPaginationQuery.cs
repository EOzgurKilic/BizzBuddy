using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.Preset.Queries.GetPresetSettingsWithPagination;



public record GetPresetSettingsWithPaginationQuery() : IRequest<Result<PaginatedList<PresetSettingsListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetPresetSettingsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetPresetSettingsWithPaginationQuery, Result<PaginatedList<PresetSettingsListDto>>>
{
    public async Task<Result<PaginatedList<PresetSettingsListDto>>> Handle(GetPresetSettingsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.PresetSettings
       .ProjectTo<PresetSettingsListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<PresetSettingsListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<PresetSettingsListDto>>.Success(result);
    }
}