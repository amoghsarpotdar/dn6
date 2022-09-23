using AspnetLoggingSample;
using System.Drawing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*
 * With minimal API approach, we don't need the ConfigureLogging method that we 
 * would have used otherwise in older ASPNetCore module 
 * <TBD:Example needed of older implementation>
 */
//builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();

builder.Logging.ClearProviders();
var config = new CustomLoggerConfiguration
{
    LogLevel = LogLevel.Information,
    Color = ConsoleColor.Blue
};
builder.Logging.AddProvider(new ColoredConsoleLoggerProvider(config));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
