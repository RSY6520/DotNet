var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// before endpoint
app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endpont = context.GetEndpoint();
    await context.Response.WriteAsync($"Endpoint {endpont?.DisplayName}\n");
    await next(context);
});

app.UseRouting();

//after endpoint

app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
    await context.Response.WriteAsync($"Endpoint: {endpoint?.DisplayName}\n");
    await next(context);
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("map1", async (context) =>
    {
        await context.Response.WriteAsync("map1");
    });

    endpoints.MapPost("map2", async context =>
    {
        await context.Response.WriteAsync("map2");
    });

    // Type of route parameters
    endpoints.Map("files/{filename}.{extension}", async (context) =>
    {
        string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"in file - {filename} - {extension}");
    });

    endpoints.Map("employee/profile/{EmployeeName: length(4, 7) : alpha=Ramakant}", async (context) =>
    {
        string? name = Convert.ToString(context.Request.RouteValues["EmployeeName"]);
        await context.Response.WriteAsync($"in file - {name}");
    });

    endpoints.Map("product/details/{id:int:range(1,1000)?}", async (context) =>
    {
    if (context.Request.RouteValues.ContainsKey("id")) {
            int id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"product id - {id}");
    }
    else {
            await context.Response.WriteAsync("product id not found");
    }
    });

    // Route Constraints
    endpoints.Map("daily-digest-report/{date:datetime}", async context =>
    {
        await context.Response.WriteAsync("correct date");
    });
    endpoints.Map("cities/{cityid: guid}", async context =>
    {
        await context.Response.WriteAsync("correct guid");
    });
    endpoints.Map("sale-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context =>
    {
        await context.Response.WriteAsync("Correct year and month");
    });
});


app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
