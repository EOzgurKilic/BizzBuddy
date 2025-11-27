using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.CustomFieldDefs.Commands.UpdateCustomFieldDefs;

public record UpdateCustomFieldDefsCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string EntityType { get; set; }
    public string Key { get; set; }
    public string Label { get; set; }
    public string DataType { get; set; }

    public bool Required { get; set; }
    public string[]? Options { get; set; }
    public int Order { get; set; }

    public bool IsActive { get; set; }
}

public class UpdateCustomFieldDefsCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateCustomFieldDefsCommand, Result>
{
    public async Task<Result> Handle(UpdateCustomFieldDefsCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.CustomFieldDef.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("CustomFieldDef not found");

        entity.EntityType = request.EntityType;
        entity.Key =request.Key;
        entity.Label = request.Label;
        entity.DataType = request.DataType;
        entity.Required = request.Required;
        entity.Options = request.Options;
        entity.Order = request.Order;
        entity.IsActive = request.IsActive;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}