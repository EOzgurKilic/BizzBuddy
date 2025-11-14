using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Orders;
using MediatR;

namespace BizBuddy.Application.Orders.Commands.CreateAppointment;

public record CreateAppointmentCommand : IRequest<Result<long>>
{
    public int CustomerId { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public string Status { get; set; }
    public string? Notes { get; set; }
    public string? Custom { get; set; }
}
public class CreateAppointmentCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateAppointmentCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {

        var entity = new Appointment
        {
            CustomerId = request.CustomerId,
            Start = request.Start,
            End = request.End,
            Status = request.Status,
            Notes = request.Notes,
            Custom = request.Custom,
        };

        context.Appointment.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }
}
