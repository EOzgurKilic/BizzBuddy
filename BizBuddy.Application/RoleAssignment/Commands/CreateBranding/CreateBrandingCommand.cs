using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.RoleAssignment;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BizBuddy.Application.RoleAssignment.Commands.CreateBranding
{
    public record CreateBrandingCommand : IRequest<Result<long>>
    {
        public string BrandName { get; set; } = default!;
        public string? LogoUrl { get; set; }
        public string? FaviconUrl { get; set; }
        public string? Background { get; set; }
        public string? Surface { get; set; }
        public string? Shadow { get; set; }
        public string? FontFamily { get; set; }
        public DarkModeSettingsDto? DarkMode { get; set; }
    }

    public sealed class DarkModeSettingsDto
    {
        public bool Enabled { get; set; } = false;
        public string? Background { get; set; }
        public string? Surface { get; set; }
        public string? Text { get; set; }
    }

    public class CreateBrandingCommandHandler(IApplicationDbContext context)
        : IRequestHandler<CreateBrandingCommand, Result<long>>
    {
        public async Task<Result<long>> Handle(CreateBrandingCommand request, CancellationToken cancellationToken)
        {
            var entity = new Branding
            {
                BrandName = request.BrandName,
                LogoUrl = request.LogoUrl,
                FaviconUrl = request.FaviconUrl,
                Background = request.Background,
                Surface = request.Surface,
                Shadow = request.Shadow,
                FontFamily = request.FontFamily,
                DarkMode = request.DarkMode == null ? null : new DarkModeSettings
                {
                    Enabled = request.DarkMode.Enabled,
                    Background = request.DarkMode.Background,
                    Surface = request.DarkMode.Surface,
                    Text = request.DarkMode.Text
                }
            };

            context.Branding.Add(entity);
            await context.SaveChangesAsync(cancellationToken);

            return Result<long>.Success(entity.Id);
        }
    }
}
