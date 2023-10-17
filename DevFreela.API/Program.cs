using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configurar as horas de operação do sistema a patrir do modelo OpeningTimeOptions, lendo as configurações do appsettings.json
//builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

// Initialized a database signleton object to initiate persistance layer
var connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

// Dependency injection between Project service interface and actual implementation
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddMediatR(typeof(CreateProjectCommand).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
