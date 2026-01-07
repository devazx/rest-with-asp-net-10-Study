using restWithASPNET10Study.Configurations;
using restWithASPNET10Study.Repositories;
using restWithASPNET10Study.Repositories.Impl;
using restWithASPNET10Study.Services;
using restWithASPNET10Study.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddLoggingConfiguration();

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddScoped<IUserService, UserServiceImpl>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
