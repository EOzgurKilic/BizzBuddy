using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Commands.DeleteAppointment;


public record DeleteAppointmentCommand(long Id) : IRequest<Result>;
public class DeleteAppointmentCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteAppointmentCommand, Result>
{
    public async Task<Result> Handle(DeleteAppointmentCommand request, CancellationToken ct)
    {
        var entity = await context.Appointment.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Customer not found.");

        context.Appointment.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

