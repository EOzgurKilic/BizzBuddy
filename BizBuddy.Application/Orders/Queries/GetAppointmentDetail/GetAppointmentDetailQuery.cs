using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Queries.GetAppointmentDetail;

public record GetAppointmentDetailQuery(int Id) : IRequest<Result<AppointmentDetailDto>>;
public class GetAppointmentDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetAppointmentDetailQuery, Result<AppointmentDetailDto>>
{
    public async Task<Result<AppointmentDetailDto>> Handle(GetAppointmentDetailQuery request, CancellationToken ct)
    {
        var entity = await context.Appointment
            .AsQueryable()
            .ProjectTo<AppointmentDetailDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<AppointmentDetailDto>.Failure("Appointment not found.");

        return Result<AppointmentDetailDto>.Success(entity);
    }
}