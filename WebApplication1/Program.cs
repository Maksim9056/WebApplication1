using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.ContentType = "text/html; charset=utf-8";
//    await response.WriteAsync("<button>Hello METANIT.COM</button>");
//});
//app.MapGet("/", () => "Hello World!");
app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";

    // если обращение идет по адресу "/postuser", получаем данные формы
    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        string name = form["name"];
        string age = form["age"];
        await context.Response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p></div>");
    }
    else
    {
        await context.Response.SendFileAsync("html/index.html");
    }
});

app.Run();
