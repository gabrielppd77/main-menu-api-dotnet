using main_menu.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigBuild();

var app = builder.Build();

app.ConfigApp();

app.Run();
