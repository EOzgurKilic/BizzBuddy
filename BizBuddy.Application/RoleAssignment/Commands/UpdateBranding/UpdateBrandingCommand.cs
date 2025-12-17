using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.RoleAssignment.Commands.CreateBranding;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.RoleAssignment.Commands.UpdateBranding;

public record UpdateBrandingCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public string? LogoUrl { get; set; }
    public string? FaviconUrl { get; set; }
    public string? Background { get; set; }
    public string? Surface { get; set; }
    public string? Shadow { get; set; }
    public string? FontFamily { get; set; }

    public DarkModeSettingsDto? DarkMode { get; set; }
}

public class UpdateBrandingCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateBrandingCommand, Result>
{
    public async Task<Result> Handle(UpdateBrandingCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Branding
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null)
            return Result.Failure("Branding not found");

        entity.BrandName = request.BrandName;
        entity.LogoUrl = request.LogoUrl;
        entity.FaviconUrl = request.FaviconUrl;
        entity.Background = request.Background;
        entity.Surface = request.Surface;
        entity.Shadow = request.Shadow;
        entity.FontFamily = request.FontFamily;

        if (request.DarkMode != null)
        {
            entity.DarkMode.Enabled = request.DarkMode.Enabled;
            entity.DarkMode.Background = request.DarkMode.Background;
            entity.DarkMode.Surface = request.DarkMode.Surface;
            entity.DarkMode.Text = request.DarkMode.Text;
        }

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}