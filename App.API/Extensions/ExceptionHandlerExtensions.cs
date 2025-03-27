using App.API.ExceptionHandlers;

namespace App.API.Extensions
{
    public static class ExceptionHandlerExtensions
    {
        public static IServiceCollection AddExceptionHandlerExt(this IServiceCollection services)
        {
            services.AddExceptionHandler<CriticalExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();

            return services;
        }

        public static IApplicationBuilder UseExceptionHandlerExt(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x => { });
            return app;
        }
    }
}
