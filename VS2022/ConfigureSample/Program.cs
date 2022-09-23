var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*
In ASP.Net Core 3.1 and ASP.Net Core 5.0, this is what configuration reading looks like -

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder => {
        webBuilder.ConfigureAppConfiguration((builderContext, config) =>{
            // All configuration settings go here
        })
        .UseStartup<Start>();
    });

*/

/*
With minimal APIs, there is much easier way to add appsettings.json file for your project.
*/
var env = builder.Environment;
builder.Configuration.SetBasePath(env.ContentRootPath);
builder.Configuration.AddJsonFile("appsettings.json", optional:false, reloadOnChange:true);
builder.Configuration.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:true, reloadOnChange:true);       // This line ensures you can keep your environment specific configuration separate.
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.SetBasePath(env.ContentRootPath);

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
