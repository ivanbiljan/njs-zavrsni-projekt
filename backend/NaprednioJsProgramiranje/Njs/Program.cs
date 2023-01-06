using System.Text.Json;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Njs.Core;
using Njs.Core.Infrastructure.PipelineBehaviours;
using Njs.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddNjs(builder.Configuration, builder.Environment);

// builder.Services.AddMvcCore().AddJsonOptions(
//     options =>
//     {
//         options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//         options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
//     });
//
// builder.Services.ConfigureHttpJsonOptions(
//     options =>
//     {
//         options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//         options.SerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
//     });

builder.Services.AddMvc()
    .AddFluentValidation(config =>
        config.RegisterValidatorsFromAssembly(typeof(ValidationBehaviour<,>).Assembly))
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseRewriter();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();