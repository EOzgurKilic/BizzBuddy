using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Preset;
using MediatR;

namespace BizBuddy.Application.Preset.Commands.CreateTenantSettings;




public record CreateTenantSettingsCommand : IRequest<Result<long>>
{
    public List<string> EnabledModules { get; set; }
    public List<string> MenuOrder { get; set; }

    
    public int BrandingId { get; set; }

}
public class CreateTenantSettingsCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateTenantSettingsCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateTenantSettingsCommand request, CancellationToken cancellationToken)
    {

        var entity = new TenantSettings
        {
            EnabledModules = request.EnabledModules,
            MenuOrder = request.MenuOrder,
           BrandingId = request.BrandingId,
        };

        context.TenantSettings.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }
}
