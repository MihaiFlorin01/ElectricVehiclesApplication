using Mappers;
using Abstractions;
using Infrastructure.GenericRepository;
using Infrastructure.Context;
using System.Reflection;
using MediatR;
using CQRS.Queries.BikeQueries;
using FluentValidation;
using Validators;
using Infrastructure.Settings;
using Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt =>
{
    opt.Filters.AddService<GlobalExceptionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddAutoMapper(typeof(Profiles).Assembly);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(typeof(ViewBikesQuery).GetTypeInfo().Assembly);

builder.Services.AddValidatorsFromAssemblyContaining<BikeValidator>();

builder.Services.AddScoped<GlobalExceptionFilter>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
