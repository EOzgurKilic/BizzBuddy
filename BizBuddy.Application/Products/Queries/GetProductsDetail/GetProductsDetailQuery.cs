using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Products.Queries.GetProductsDetail;

public record GetProductsDetailQuery(int Id) : IRequest<Result<ProductsDto>>;
public class GetProductsDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetProductsDetailQuery, Result<ProductsDto>>
{
    public async Task<Result<ProductsDto>> Handle(GetProductsDetailQuery request, CancellationToken ct)
    {
        var entity = await context.Product
            .AsQueryable()
            .ProjectTo<ProductsDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<ProductsDto>.Failure("Product not found");

        return Result<ProductsDto>.Success(entity);
    }
}
