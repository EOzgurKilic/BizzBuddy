using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Staff.Queries.GetEmployeeDetail;

public record GetEmployeeDetailQuery(int Id) : IRequest<Result<EmployeeDto>>;
public class GetEmployeeDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetEmployeeDetailQuery, Result<EmployeeDto>>
{
    public async Task<Result<EmployeeDto>> Handle(GetEmployeeDetailQuery request, CancellationToken ct)
    {
        var entity = await context.Employee
            .AsQueryable()
            .ProjectTo<EmployeeDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<EmployeeDto>.Failure("Employee not found");

        return Result<EmployeeDto>.Success(entity);
    }
}
