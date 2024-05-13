using Microsoft.EntityFrameworkCore;
using TestRedAfectiva.Infrastructure;
using FastEndpoints;
using FastEndpoints.Swagger;
using System;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using TestRedAfectiva.Core;
using Ardalis.ListStartupServices;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});


string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddFastEndpoints();

builder.Services.SwaggerDocument(o =>
{
    o.ShortSchemaNames = true;
});

builder.Services.AddCors(options =>
{
    //Configuracion de Cors para app react
    options.AddPolicy("MyAllowSpecificOrigins",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacInfrastructureModule(builder.Environment.IsDevelopment()));
});


var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseShowAllServicesMiddleware(); // see https://github.com/ardalis/AspNetCoreStartupServices
}
else
{
    app.UseDefaultExceptionHandler(); // from FastEndpoints
    app.UseHsts();
}

app.UseCors("MyAllowSpecificOrigins");

app.UseFastEndpoints();
app.UseSwaggerGen(); // FastEndpoints middleware

app.UseHttpsRedirection();


app.Run();

public partial class Program
{
}
