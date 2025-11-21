using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Categories.Commands.DeleteCategories;

public record DeleteCategoriesCommand(long Id) : IRequest<Result>;
public class DeleteCategoriesCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteCategoriesCommand, Result>
{
    public async Task<Result> Handle(DeleteCategoriesCommand request, CancellationToken ct)
    {
        var entity = await context.Category.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Category not found.");

        context.Category.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

