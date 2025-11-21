using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.CustomFieldDefs.Commands.DeleteCustomFieldDefs;



public record DeleteCustomFieldDefsCommand(long Id) : IRequest<Result>;
public class DeleteCustomFieldDefsCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteCustomFieldDefsCommand, Result>
{
    public async Task<Result> Handle(DeleteCustomFieldDefsCommand request, CancellationToken ct)
    {
        var entity = await context.CustomFieldDef.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("CustomFieldDef not found.");

        context.CustomFieldDef.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

