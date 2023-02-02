using APIDependencyInjection;
using TaxCalculatorAPI.Middlewares;

namespace TaxCalculatorAPI
{
    public class Startup
    {
        private IConfiguration configuration { get; }
        private IHostEnvironment environment { get; }

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void AddDependencies(IServiceCollection services)
        {
            services.AddServiceDependency();
        }

        public void AddConfiguration(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureHTTPRequestPipeline(app, env);

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseMiddleware<ValidationExceptionHandlingMiddleware>();
            app.UseMiddleware<BadRequestExceptionHandlingMiddleware>();
            app.UseMiddleware<NotFoundExceptionHandlingMiddleware>();
        }

        protected void ConfigureHTTPRequestPipeline(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
