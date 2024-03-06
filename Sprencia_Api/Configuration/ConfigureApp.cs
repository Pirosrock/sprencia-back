using Sprencia_Api.Middlewares;

namespace Sprencia_Api.Configuration
{
    internal static class ConfigureApp
    {
        internal static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
            app.UseCors(app.Configuration["CORS:PolicyName"]);

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
