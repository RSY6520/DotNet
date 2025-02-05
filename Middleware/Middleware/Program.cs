using Middleware.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleware1>();
var app = builder.Build();

//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Hello");
//});

//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Hello again");
//});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello");
    await next(context);
});

//app.UseCustomMiddleware1();
app.UseHelloCustomMiddleware();

app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("From UseWhen");
            await next(context);
        });
    });

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello again");
});

app.Run();
