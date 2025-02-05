
namespace Middleware.CustomMiddlewares
{
    public class CustomMiddleware1 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("custom 1 starts from extension");
            await next(context);
            await context.Response.WriteAsync("custom 1 ends");
        }
    }

    // extension method for easy registration

    public static class CustomMiddleware1Extension
    {
        public static IApplicationBuilder UseCustomMiddleware1(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware1>();
        }
    }
}
