using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Queries.GetOrderDetail;

public record GetOrderDetailQuery(int Id) : IRequest<Result<OrderDetailDto>>;
public class GetOrderDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetOrderDetailQuery, Result<OrderDetailDto>>
{
    public async Task<Result<OrderDetailDto>> Handle(GetOrderDetailQuery request, CancellationToken ct)
    {
        var entity = await context.Order
            .AsQueryable()
            .ProjectTo<OrderDetailDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<OrderDetailDto>.Failure("Order not found.");

        return Result<OrderDetailDto>.Success(entity);
    }
}