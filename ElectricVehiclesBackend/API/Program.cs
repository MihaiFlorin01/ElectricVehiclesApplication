using Mappers;
using Microsoft.EntityFrameworkCore;
using Abstractions;
using Infrastructure.GenericRepository;
using Infrastructure.Context;
using System.Reflection;
using MediatR;
using CQRS.Queries.BikeQueries;
using FluentValidation.AspNetCore;
using FluentValidation;
using Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(Profiles).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(typeof(ViewBikesQuery).GetTypeInfo().Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<BikeValidator>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
