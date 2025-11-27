using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Users.Commands.UpdateUsers;

public record UpdateUsersCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string DisplayName { get; set; }

    public string Email { get; set; }

    public string? Phone { get; set; }

    public string PasswordHash { get; set; }
    public int RoleId { get; set; }
}

public class UpdateUsersCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateUsersCommand, Result>
{
    public async Task<Result> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.User.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("User not found");

        entity.DisplayName = request.DisplayName;
        entity.Email = request.Email;
        entity.Phone = request.Phone;
        entity.PasswordHash = request.PasswordHash;
        entity.RoleId = request.RoleId;
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}