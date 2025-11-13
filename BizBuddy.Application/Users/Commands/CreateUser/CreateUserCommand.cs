using System;
using AutoMapper;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Account;
using BizBuddy.Domain.Entities.RoleAssignment;
using BizBuddy.Domain.Entities.Tenats;
using MediatR;

namespace BizBuddy.Application.Users.Commands.CreateUser;

public record CreateUserCommand : IRequest<Result<long>>
{
    public string DisplayName { get; set; }

    public string Email { get; set; }

    public string? Phone { get; set; }

    public string PasswordHash { get; set; }
    public int RoleId { get; set; }
}
public class CreateUserCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateUserCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var entity = new User
        {
            DisplayName = request.DisplayName,
            Email = request.Email,
            Phone = request.Phone,
            PasswordHash = request.PasswordHash,
            RoleId = request.RoleId
        };

        context.User.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }




}
