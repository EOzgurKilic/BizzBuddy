using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Categories;
using MediatR;

namespace BizBuddy.Application.Categories.Commands.CreateCategories;

public record CreateCategoriesCommand : IRequest<Result<long>>
{
    public string Name { get; set; } = default!;
    public int? ParentId { get; set; }
    public string? Type { get; set; }
    public int? SortOrder { get; set; }
}
public class CreateCategoriesCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateCategoriesCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateCategoriesCommand request, CancellationToken cancellationToken)
    {

        var entity = new Category
        {
            Name = request.Name,
            ParentId = request.ParentId,
            Type = request.Type,
            SortOrder = request.SortOrder
        };

        context.Category.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }




}
