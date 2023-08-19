using System;
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
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http;
using System.Text;
using RealTimeUber.Configuration;
using NLog.Extensions.Logging;
using NLog.Web;
using NLog;
using LoggerService;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Builder;
using System.Globalization;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));


#region Localization and Golbalization

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "en-US", "ar-SA" };
    options.SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});

#endregion




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.ConfigureLoggerService();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo
    {
        Version = "V1",
        Title = "WebAPI",
        Description = "Product WebAPI"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});



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


builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = ConfigurationManagerr.AppSetting["JWT:ValidIssuer"],
            ValidAudience = ConfigurationManagerr.AppSetting["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManagerr.AppSetting["JWT:Secret"]))
        };
    });

var app = builder.Build();

var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(Options =>
    {
        app.UseSwaggerUI(options => {
            options.SwaggerEndpoint("/swagger/V1/swagger.json", "Uber Simulation WebAPI");
        });
    });
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.UseMiddleware<ResponseMiddleware>();
app.UseCors(policy =>
{
    policy.AllowAnyMethod()
          .AllowAnyHeader()
          .AllowAnyOrigin();
});

//app.MapGet("/api/vehicles", (IStringLocalizer<Program> localizer) =>
//{
//    // Get the localized string based on the current culture
//    var localizedString = localizer["Welcome"];

//    return localizedString;
//});


app.Run();






