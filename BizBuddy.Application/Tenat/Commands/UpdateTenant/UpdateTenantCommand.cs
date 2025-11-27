using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Tenat.Commands.UpdateTenant;

public record UpdateTenantCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? PresetName { get; set; }
}

public class UpdateTenantCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateTenantCommand, Result>
{
    public async Task<Result> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Tenat.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("InventoryMove not found");

        entity.Name = request.Name;
        entity.PresetName = request.PresetName;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}