using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Data.Services.ServicesImplementation;
using Microsoft.Extensions.FileProviders;
using System.Text.RegularExpressions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IAllowedValuesService, AllowedValuesService>();
builder.Services.AddSingleton<IConnectToAPI, ConnectToAPI>();
//builder.Services.AddScoped<ITokenService, TokenService>();
//builder.Services.AddScoped<CustomAuthenticationStateProvider, CustomAuthenticationStateProvider>();
//builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetService<CustomAuthenticationStateProvider>());

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

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Regex.Replace(app.Environment.ContentRootPath, $"{app.Environment.ApplicationName}$", "Assets")),
    RequestPath = "/Assets",
    OnPrepareResponse = ctx =>
    {
        // Optionally manipulate the response as you'd like. for example, I'm setting a no-cache directive here for dev.
        ctx.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
    }
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
