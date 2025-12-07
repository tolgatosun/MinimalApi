using API.Extensions;
using FluentValidation;
using Model.Valid;
using Serilog;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.    
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    var watch = Stopwatch.StartNew();
    await next();
    watch.Stop();

    Log.Information("Request {Path} responded in {Elapsed} ms",
        context.Request.Path, watch.ElapsedMilliseconds);
});

app.MapEndpoints();

app.Run();