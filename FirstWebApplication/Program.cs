var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseWelcomePage();

//app.MapGet("/t", () => "Hello World!");

int x = 2;
app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Result: {x *= 2}");
});

//app.Run();
