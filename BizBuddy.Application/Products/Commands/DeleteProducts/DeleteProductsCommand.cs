using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Products.Commands.DeleteProducts;

public record DeleteProductsCommand(long Id) : IRequest<Result>;
public class DeleteProductsCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteProductsCommand, Result>
{
    public async Task<Result> Handle(DeleteProductsCommand request, CancellationToken ct)
    {
        var entity = await context.Product.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Product not found.");

        context.Product.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

