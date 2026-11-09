using MiddlewearAsClass;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseMiddleware<TokenMiddleWear>("111");
//Использование через расширение
app.UseToken("55555");

app.Run(async context => await context.Response.WriteAsync("Hello World!"));

app.Run();
