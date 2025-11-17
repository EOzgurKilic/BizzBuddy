using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Products;
using MediatR;

namespace BizBuddy.Application.Products.Commands.CreateProducts;

public record CreateProductsCommand : IRequest<Result<long>>
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public string? Sku { get; set; }
    public decimal Price { get; set; }
    public decimal? StockQty { get; set; }
    public string? Unit { get; set; }
}
public class CreateProductsCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateProductsCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
    {

        var entity = new Product
        {
            Name = request.Name,
            CategoryId = request.CategoryId,
            Sku = request.Sku,
            Price = request.Price,
            StockQty = request.StockQty,
            Unit = request.Unit,
        };

        context.Product.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }




}
