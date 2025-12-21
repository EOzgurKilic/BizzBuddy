using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Categories.Queries.GetCategoriesDetail;

public record GetCategoriesDetailQuery(int Id) : IRequest<Result<CategoriesDto>>;
public class GetCategoriesDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetCategoriesDetailQuery, Result<CategoriesDto>>
{
    public async Task<Result<CategoriesDto>> Handle(GetCategoriesDetailQuery request, CancellationToken ct)
    {
        var entity = await context.Category
            .AsQueryable()
            .ProjectTo<CategoriesDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (entity is null)
            return Result<CategoriesDto>.Failure("Category Not found");

        return Result<CategoriesDto>.Success(entity);
    }
}
