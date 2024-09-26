using Dimchev.DiceRoller.Auth.Core;
using Dimchev.DiceRoller.Auth.Infrastructure;
using Dimchev.DiceRoller.Auth.Infrastructure.Configuration;
using Dimchev.DiceRoller.Auth.WebApi.Middleware;
using Dimchev.DiceRoller.Auth.WebApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
builder.Services.AddFluentValidationAutoValidation();
// builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCoreApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.Section));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();

app.Run();
