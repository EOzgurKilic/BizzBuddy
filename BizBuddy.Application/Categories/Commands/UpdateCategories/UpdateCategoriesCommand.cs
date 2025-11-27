using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Categories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Categories.Commands.UpdateCategories;

public record UpdateCategoriesCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int? ParentId { get; set; }
    public string? Type { get; set; }
    public int? SortOrder { get; set; }
}
public class UpdateCategoriesCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateCategoriesCommand, Result>
{
    public async Task<Result> Handle(UpdateCategoriesCommand request, CancellationToken cancellationToken)
    {

        var entity = await context.Category.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null)
            return Result.Failure("Category not found");

        entity.Name = request.Name;
        entity.ParentId = request.ParentId;
        entity.Type = request.Type;
        entity.SortOrder = request.SortOrder;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}