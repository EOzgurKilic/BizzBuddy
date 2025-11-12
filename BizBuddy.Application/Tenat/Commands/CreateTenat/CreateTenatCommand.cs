using System;
using AutoMapper;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Tenats;
using MediatR;


namespace BizBuddy.Application.Tenat.Commands.CreateTenat;
public record CreateTenatCommand : IRequest<Result<long>>
{
    public string Name { get; set; }
    public string? PresetName { get; set; }
}
public class CreateTenatCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateTenatCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateTenatCommand request, CancellationToken cancellationToken)
    {

        var entity = new Tenantt
        {
            Name = request.Name,
            PresetName = request.PresetName,
        };

        context.Tenat.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }




}
