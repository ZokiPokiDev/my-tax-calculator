using APIDependencyInjection;
using FluentValidation;
using MediatR;
using System.Reflection;
using TaxCalculatorAPI.Behaviours;
using TaxCalculatorAPI.Middlewares;
using TaxCalculatorAPI.Services;

namespace TaxCalculatorAPI
{
    public class DependencyInjection : DependencyStartup
    {
        public override void AddServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Register Fluent Validation service
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Register MediatR Services
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddTransient<ValidationExceptionHandlingMiddleware>();
            services.AddTransient<BadRequestExceptionHandlingMiddleware>();
            services.AddTransient<NotFoundExceptionHandlingMiddleware>();

            services.AddScoped<IPurchaseService, PurchaseService>();
        }
    }
}
