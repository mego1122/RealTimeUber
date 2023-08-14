using Microsoft.Extensions.Configuration;
using System;

using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RealTimeUber.Models;
using Microsoft.EntityFrameworkCore;
using RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface;
using RealTimeUber.GenericResponse;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Data_Access_Layer.Repository_Classes;
using RealTimeUber.Data_Access_Layer;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<TrackingContext>(options => options.UseSqlServer(
    configuration.GetConnectionString("DefaultConnection")),
  ServiceLifetime.Scoped);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
//builder.Services.AddDbContextPool<TrackingContext>(o => o.UseSqlServer("Specify the database connection string here..."));
//builder.Services.AddDbContext<TrackingContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
      policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddCors();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



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
app.UseMiddleware<ResponseMiddleware>();
app.UseCors(policy =>
{
    policy.AllowAnyMethod()
          .AllowAnyHeader()
          .AllowAnyOrigin();
});


app.Run();




