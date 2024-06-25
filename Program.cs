using main_menu.configurations;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigBuild();

var app = builder.Build();

app.ConfigApp();

app.Run();
