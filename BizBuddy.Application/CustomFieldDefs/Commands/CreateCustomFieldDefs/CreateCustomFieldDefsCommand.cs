using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.CustomFieldDefs;
using MediatR;

namespace BizBuddy.Application.CustomFieldDefs.Commands.CreateCustomFieldDefs;

public record CreateCustomFieldDefsCommand : IRequest<Result<long>>
{
    public string EntityType { get; set; }
    public string Key { get; set; }
    public string Label { get; set; }
    public string DataType { get; set; }
    public bool Required { get; set; }
    public string[]? Options { get; set; }
    public int Order { get; set; }
    public bool IsActive { get; set; }
}
public class CreateCustomFieldDefsCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateCustomFieldDefsCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateCustomFieldDefsCommand request, CancellationToken cancellationToken)
    {

        var entity = new CustomFieldDef
        {
            EntityType = request.EntityType,
            Key = request.Key,
            Label = request.Label,
            DataType = request.DataType,
            Required = request.Required,
            Options = request.Options,
            Order = request.Order,
            IsActive = request.IsActive
        };

        context.CustomFieldDef.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }




}
