using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Orders;
using MediatR;

namespace BizBuddy.Application.Orders.Commands.CreatePayment;



public record CreatePaymentCommand : IRequest<Result<long>>
{
    public int OrderId { get; set; }

    public decimal Amount { get; set; }
    public string Method { get; set; }
    public string? ProviderRef { get; set; }
    public string? Notes { get; set; }
}
public class CreatePaymentCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreatePaymentCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {

        var entity = new Payment
        {
            OrderId = request.OrderId,
            Amount = request.Amount,
            Method = request.Method,
            ProviderRef = request.ProviderRef,
            Notes = request.Notes,
        };

        context.Payment.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }
}
