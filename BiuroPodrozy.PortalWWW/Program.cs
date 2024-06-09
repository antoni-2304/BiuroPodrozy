using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Data.Services.ServicesImplementation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.RegularExpressions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
	.AddCookie(options =>
	{
		options.LoginPath = "/Auth";

		options.Events = new CookieAuthenticationEvents
		{
			OnSigningIn = context =>
			{
				var accessToken = context.Principal.FindFirst("AccessToken")?.Value;
				if (!string.IsNullOrEmpty(accessToken))
				{
					context.HttpContext.Response.Cookies.Append("AccessToken", accessToken, new CookieOptions
					{
						HttpOnly = true,
						Secure = true
					});
				}
				return Task.CompletedTask;
			}
		};
	})
	.AddJwtBearer(options =>
	{
		options.Events = new JwtBearerEvents
		{
			OnMessageReceived = context =>
			{
				var accessToken = context.HttpContext.Request.Cookies["AccessToken"];
				if (!string.IsNullOrEmpty(accessToken))
				{
					context.Token = accessToken;
				}
				return Task.CompletedTask;
			}
		};
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
		};
	});

builder.Services.AddControllersWithViews();



builder.Services.AddSingleton<IAllowedValuesService, AllowedValuesService>();
builder.Services.AddSingleton<IConnectToAPI, ConnectToAPI>();
builder.Services.AddScoped<ITokenService, HttpOnlyTokenService>();

builder.Services.AddAuthorization();

builder.Services.AddMvc(options => options.Filters.Add(new
				 RequireHttpsAttribute()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
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
		ctx.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
	}
});


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();