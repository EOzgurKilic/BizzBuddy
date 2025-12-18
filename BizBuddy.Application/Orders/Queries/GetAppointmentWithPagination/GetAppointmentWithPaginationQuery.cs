using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.Orders.Queries.GetAppointmentWithPagination;
public record GetAppointmentWithPaginationQuery() : IRequest<Result<PaginatedList<AppointmentListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetAppointmentWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetAppointmentWithPaginationQuery, Result<PaginatedList<AppointmentListDto>>>
{
    public async Task<Result<PaginatedList<AppointmentListDto>>> Handle(GetAppointmentWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.Appointment
       .ProjectTo<AppointmentListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<AppointmentListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<AppointmentListDto>>.Success(result);
    }
}