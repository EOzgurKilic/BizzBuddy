using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(long Id) : IRequest<Result>;
public class DeleteUserCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteUserCommand, Result>
{
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken ct)
    {
        var entity = await context.User.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("User not found.");

        context.User.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

