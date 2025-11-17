using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Account;
using BizBuddy.Domain.Entities.RoleAssignment;
using MediatR;

namespace BizBuddy.Application.RoleAssignment.Commands.CreateRole;



public record CreateRoleCommand : IRequest<Result<long>>
{
    public string RoleName { get; set; } = default!;
    public string? Description { get; set; }
    public List<int>? UserIds { get; set; } = new();

}
public class CreateRoleCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateRoleCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {

        var entity = new Role
        {
            RoleName = request.RoleName,
            Description = request.Description,
            Users = request.UserIds?.Select(id => new User { Id = id }).ToList() ?? new List<User>()
        };


        context.Role.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }
}
