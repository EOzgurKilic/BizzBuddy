using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;
using FluentValidation;
using System.Reflection;
using BizBuddy.Application.Common.Behaviors;

namespace BizBuddy.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // MediatR 13.x için
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly())
            );

            // Pipeline Behavior (FluentValidation tetiklenecek)
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // AutoMapper
// "AddAutoMapper" metodunu çağırmıyoruz, direkt kütüphanenin kendisini kuruyoruz
var mapperConfig = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddMaps(System.Reflection.Assembly.GetExecutingAssembly());
});

AutoMapper.IMapper mapper = mapperConfig.CreateMapper();
services.AddSingleton(mapper);            // FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            

            return services;
        }
    }
}
