using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Customers.Queries.GetCustomerDetail;


public record GetCustomerDetailQuery(long Id) : IRequest<Result<CustomersDto>>;
public class GetCustomerDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetCustomerDetailQuery, Result<CustomersDto>>
{
    public async Task<Result<CustomersDto>> Handle(GetCustomerDetailQuery request, CancellationToken ct)
    {
        var entity = await context.Customer
            .AsQueryable()
            .ProjectTo<CustomersDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<CustomersDto>.Failure("Not found");

        return Result<CustomersDto>.Success(entity);
    }
}
