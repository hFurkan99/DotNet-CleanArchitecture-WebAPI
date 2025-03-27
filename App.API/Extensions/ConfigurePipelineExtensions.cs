namespace App.API.Extensions
{
    public static class ConfigurePipelineExtensions
    {
        public static IApplicationBuilder UseConfigurePipelineExt(this WebApplication app)
        {
            app.UseExceptionHandlerExt();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerExt();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            return app;
        }
    }
}
