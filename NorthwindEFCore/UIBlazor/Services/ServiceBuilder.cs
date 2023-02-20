using Business.Classes;
using Business.Interfaces;
using Core.Helper;
using DataAccess.Classes;
using DataAccess.Interfaces;
using Entities.Context;
using UIBlazor.Data;
namespace UIBlazor.Services;
public static class ServiceBuilder
{
    public static WebApplication Builder()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddDbContext<NorthwindContext>();
        builder.Services.AddScoped<IServiceCategory, ServiceCategory>();
        builder.Services.AddScoped<IServiceProduct, ServiceProduct>();
        builder.Services.AddScoped(typeof(IEntityRepo<>), typeof(EntityRepo<>));
        builder.Services.AddAutoMapper(typeof(MappingProfiles));
        builder.Services.AddDevExpressBlazor();
        return builder.Build();
    }
}
