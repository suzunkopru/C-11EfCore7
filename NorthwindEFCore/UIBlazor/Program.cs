using UIBlazor.Data;
using Entities.Context;
using DataAccess.Classes;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<NorthwindContext>();
builder.Services.AddScoped<DalCategory>();
builder.Services.AddScoped<DalProduct>();
builder.Services.AddDevExpressBlazor();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
