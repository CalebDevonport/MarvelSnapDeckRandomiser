using ElectronNET.API.Entities;
using ElectronNET.API;
using MarvelSnapDeckRandomiser.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      });
});

// Add services to the container.

//builder.WebHost.UseElectron(args);

//builder.Services.AddElectron();

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IUrlService, UrlService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

await app.StartAsync();

// Open the Electron-Window here
//await Electron.WindowManager.CreateWindowAsync();

app.WaitForShutdown();
