
using main_menu.extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Config();

var app = builder.Build();


app.Config();

app.Run();
