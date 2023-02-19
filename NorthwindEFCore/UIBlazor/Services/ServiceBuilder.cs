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
        builder.Services.AddScoped<IDalCategory, DalCategory>();
        builder.Services.AddScoped<IDalProduct, DalProduct>();
        builder.Services.AddAutoMapper(typeof(MappingProfiles));
        builder.Services.AddDevExpressBlazor();
        return builder.Build();
    }
}
