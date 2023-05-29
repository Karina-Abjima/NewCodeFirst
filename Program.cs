using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Assignment_CFA.Data;
using AutoMapper;
using Assignment_CFA.Mapper;
using Assignment_CFA.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Assignment_CFAContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Assignment_CFAContext") ?? throw new InvalidOperationException("Connection string 'Assignment_CFAContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Automapper).Assembly);
builder.Services.AddTransient<IStudentRepo, StudentRepo>();

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
