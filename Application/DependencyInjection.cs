using Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using WebApi.DBHelper;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection service)
        {

            service.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return service;
        }
    }
}
