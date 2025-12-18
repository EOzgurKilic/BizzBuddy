using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.InventoryMoves;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.InventoryMoves.Queries.GetInventoryMovesDetail;

public record GetInventoryMovesDetailQuery(int Id) : IRequest<Result<InventoryMovesDetailDto>>;
public class GetInventoryMovesDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetInventoryMovesDetailQuery, Result<InventoryMovesDetailDto>>
{
    public async Task<Result<InventoryMovesDetailDto>> Handle(GetInventoryMovesDetailQuery request, CancellationToken ct)
    {
        var entity = await context.InventoryMove
            .AsQueryable()
            .ProjectTo<InventoryMovesDetailDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<InventoryMovesDetailDto>.Failure("InventoryMove not found.");

        return Result<InventoryMovesDetailDto>.Success(entity);
    }
}
