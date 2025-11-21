using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Commands.DeletePayment;

public record DeletePaymentCommand(long Id) : IRequest<Result>;
public class DeletePaymentCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeletePaymentCommand, Result>
{
    public async Task<Result> Handle(DeletePaymentCommand request, CancellationToken ct)
    {
        var entity = await context.Payment.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Customer not found.");

        context.Payment.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

