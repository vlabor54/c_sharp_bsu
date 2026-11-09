var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// int x = 2;
// app.Run(async (context) =>
// {
//     await context.Response.WriteAsync($"Result: {x *= 2}");
// });

// app.Run(async (context) =>
// {
//    context.Response.Headers.ContentType = "text/html; charset=utf-8";
//    context.Response.Headers.ContentLanguage = "ru-RU";
//    context.Response.StatusCode = 200;

//    await context.Response.WriteAsync("Привет!!!");
// });

// app.Run(async (context) =>
// {
//    var response = context.Response;
//    response.ContentType = "text/html; charset=utf-8";
//    await response.WriteAsync("<h2>Hello</h2><h3>Welcome to ASP.NET Core</h3>");
// });

//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<table>");

// app.Run(async (context) =>
// {
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<table>");

//    foreach (var header in context.Request.Headers)
//    {
//        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
// });

// app.Run(async (context) =>
// {
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<table>");
//    stringBuilder.Append($"Путь: {context.Request.Path}");
//    stringBuilder.Append($"QueryString: {context.Request.QueryString}");
//    stringBuilder.Append("<table>");
//    foreach (var param in context.Request.Query)
//    {
//        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");

//    await context.Response.WriteAsync(stringBuilder.ToString());
// });

app.Run(async (context) =>
{
   context.Response.ContentType = "text/html; charset=utf-8";

   //Отправка одного файла
   //await context.Response.SendFileAsync("html/index.html");

   var path = context.Request.Path;
   var fullPath = $"html/{path}";

   if (File.Exists(fullPath))
   {
       await context.Response.SendFileAsync(fullPath);
   }
   else if (context.Request.Path == "/postuser" && context.Request.Method == HttpMethod.Post.ToString())
   {
       var form = context.Request.Form;
       await context.Response.WriteAsync($"<div><p>Имя {form["name"]}</p><p>Возраст {form["age"]} </p></div>");
   }
   else if (context.Request.Path == "/contacts")
   {
       //Перенаправление запроса
       context.Response.Redirect("https://ya.ru");
   }
   else
   {
       /*        context.Response.StatusCode = 404;
               await context.Response.WriteAsync("Файл не найден");*/

       await context.Response.SendFileAsync("html/index.html");

   }
});

app.Run();
