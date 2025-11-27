using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Commands.UpdateAppointment;

public record UpdateAppointmentCommand : IRequest<Result>
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public string Status { get; set; }
    public string? Notes { get; set; }
    public string? Custom { get; set; }
}

public class UpdateAppointmentCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateAppointmentCommand, Result>
{
    public async Task<Result> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Appointment.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("Appointment not found");

        entity.CustomerId= request.CustomerId;
        entity.Start = request.Start;
        entity.End = request.End;
        entity.Status = request.Status;
        entity.Notes = request.Notes;
        entity.Custom = request.Custom;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}