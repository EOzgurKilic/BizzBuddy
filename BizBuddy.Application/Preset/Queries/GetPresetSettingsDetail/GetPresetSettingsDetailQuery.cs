using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Preset.Queries.GetPresetSettingsDetail;

public record GetPresetSettingsDetailQuery(int Id) : IRequest<Result<PresetSettingsDetailDto>>;
public class GetPresetSettingsDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetPresetSettingsDetailQuery, Result<PresetSettingsDetailDto>>
{
    public async Task<Result<PresetSettingsDetailDto>> Handle(GetPresetSettingsDetailQuery request, CancellationToken ct)
    {
        var entity = await context.PresetSettings
            .AsQueryable()
            .ProjectTo<PresetSettingsDetailDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<PresetSettingsDetailDto>.Failure("PresetSettings not found.");

        return Result<PresetSettingsDetailDto>.Success(entity);
    }
}