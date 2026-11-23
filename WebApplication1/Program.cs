using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.Design.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.UseWelcomePage();

//app.Run(async (context) => await context.Response.WriteAsync("Hello"));
//Переменные
//int x = 0;
//app.Run(async (context) => {

//    x += 1;
//    await context.Response.WriteAsync($"X = {x}");
//});

//Заголовки
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.Headers.ContentLanguage = "ru-RU";
//    response.Headers.ContentType = "text/plain;charset=utf-8";
//    response.Headers.Append("test", "123");
//    await response.WriteAsync("Привет!");
//});

//Код статуса
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.StatusCode = 404;
//    await response.WriteAsync("Not found!");
//});

//Html
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.Headers.ContentLanguage = "ru-RU";
//    response.Headers.ContentType = "text/html;charset=utf-8";
//    response.Headers.Append("test", "123");
//    await response.WriteAsync("<h1>Привет!<h1>");
//});

//Заголовки клиента
//app.Run(async(context) => { 
//    var sb = new StringBuilder();
//    sb.Append("<table>");
//    foreach(var header in context.Request.Headers)
//    {
//        sb.Append($"<tr><td>{ header.Key}</td><td>{header.Value}</td></tr>");
//    };

//    sb.Append("</table>");

//    await context.Response.WriteAsync(sb.ToString());
//});

//Пути запроса
//app.Run(async (context) => {
//    var qParam = context.Request.Query["q"];
//    await context.Response.WriteAsync($"{context.Request.Path} {context.Request.QueryString} q={qParam}" ); //context.Request.Path;

//});

//Файл
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html";
//    await context.Response.SendFileAsync("html/main.html");
//});


app.Run(async (context) => {
    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        var name = form["name"];
        var age = form["age"];
        await context.Response.WriteAsync($"{name} {age}");
    } else
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync("html/main.html");
    }
});


app.Run();
//await app.RunAsync();
//await Task.Delay(10000);
//await app.StopAsync();
