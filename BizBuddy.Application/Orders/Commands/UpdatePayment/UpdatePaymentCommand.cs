using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Commands.UpdatePayment;

public record UpdatePaymentCommand : IRequest<Result>
{
  public int Id { get; set; }

    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; } 
    public string? ProviderRef { get; set; }
    public DateTime PaidAt { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; } 
}

public class UpdatePaymentCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdatePaymentCommand, Result>
{
    public async Task<Result> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Payment.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("Payment not found");

        entity.OrderId = request.OrderId;
        entity.Amount = request.Amount;
        entity.Method = request.Method;
        entity.ProviderRef = request.ProviderRef;
        entity.Notes = request.Notes;
        entity.PaidAt = request.PaidAt;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}