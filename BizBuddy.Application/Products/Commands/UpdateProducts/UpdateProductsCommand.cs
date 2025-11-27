using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Products.Commands.UpdateProducts;

public record UpdateProductsCommand : IRequest<Result>
{
     public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public string? Sku { get; set; }
    public decimal Price { get; set; }
    public decimal? StockQty { get; set; }
    public string? Unit { get; set; }
}

public class UpdateProductsCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateProductsCommand, Result>
{
    public async Task<Result> Handle(UpdateProductsCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Product.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("Product not found");

        entity.Name = request.Name;
        entity.CategoryId = request.CategoryId;
        entity.Sku = request.Sku;
        entity.Price = request.Price;
        entity.StockQty = request.StockQty;
        entity.Unit = request.Unit;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}