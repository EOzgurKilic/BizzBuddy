using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using BizBuddy.Domain.Entities.Orders;
using MediatR;

namespace BizBuddy.Application.Orders.Queries.GetPaymentWithPagination;

public record GetPaymentWithPaginationQuery() : IRequest<Result<PaginatedList<PaymentListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetPaymentWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetPaymentWithPaginationQuery, Result<PaginatedList<PaymentListDto>>>
{
    public async Task<Result<PaginatedList<PaymentListDto>>> Handle(GetPaymentWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.Payment
       .ProjectTo<PaymentListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<PaymentListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<PaymentListDto>>.Success(result);
    }
}