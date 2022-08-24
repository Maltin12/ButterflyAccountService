using Butterfly.Account.Application.Infrastucture.Mediator;
using Butterfly.Account.Application.Services.Users.Commands.Add;
using MediatR;


namespace Butterfly.Account.Host.Configurations.Extensions
{
    public static class MediatorExtension
    {
        public static void RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddCommandHandler).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
        }
    }
}