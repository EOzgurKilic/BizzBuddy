using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Customers;
using MediatR;

namespace BizBuddy.Application.Customers.Commands.CreateCustomers;

public record CreateCustomersCommand : IRequest<Result<long>>
{
    public string Name { get; set; } = default!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Tags { get; set; }
    public string? Notes { get; set; }
    public string? Address { get; set; }
    public string? Password { get; set; }
}
public class CreateCustomersCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateCustomersCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateCustomersCommand request, CancellationToken cancellationToken)
    {

        var entity = new Customer
        {
            Name = request.Name,
            Phone = request.Phone,
            Email = request.Email,
            Tags = request.Tags,
            Notes = request.Notes,
            Address = request.Address,
            Password = request.Password
        };

        context.Customer.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }




}
