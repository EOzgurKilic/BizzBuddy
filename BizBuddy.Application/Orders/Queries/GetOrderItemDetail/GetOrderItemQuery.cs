using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Orders.Commands.CreateOrder;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Queries.GetOrderItemDetail;
public record GetOrderItemQuery(int Id) : IRequest<Result<OrderItemDetailDto>>;
public class GetOrderItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetOrderItemQuery, Result<OrderItemDetailDto>>
{
    public async Task<Result<OrderItemDetailDto>> Handle(GetOrderItemQuery request, CancellationToken ct)
    {
        var entity = await context.OrderItem
            .AsQueryable()
            .ProjectTo<OrderItemDetailDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<OrderItemDetailDto>.Failure("OrderItem not found.");

        return Result<OrderItemDetailDto>.Success(entity);
    }
}