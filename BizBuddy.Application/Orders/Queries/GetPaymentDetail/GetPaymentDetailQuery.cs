using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Queries.GetPaymentDetail;

public record GetPaymentDetailQuery(int Id) : IRequest<Result<PaymentDetailDto>>;
public class GetPaymentDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetPaymentDetailQuery, Result<PaymentDetailDto>>
{
    public async Task<Result<PaymentDetailDto>> Handle(GetPaymentDetailQuery request, CancellationToken ct)
    {
        var entity = await context.Payment
            .AsQueryable()
            .ProjectTo<PaymentDetailDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<PaymentDetailDto>.Failure("Payment not found.");

        return Result<PaymentDetailDto>.Success(entity);
    }
}