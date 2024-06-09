using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Data.Services.ServicesImplementation;
using BiuroPodrozy.Data.Utilities.Others;
using BiuroPodrozyApp.ViewModels;
using Blazing.Mvvm;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System.Diagnostics;

namespace BiuroPodrozyApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>();

            builder.Services.AddScoped(sp => new HttpClient());

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();

            builder.Services.AddAuthenticationCore();
            builder.Services.AddMvvmNavigation();
            builder.Services.AddSingleton<IConnectToAPI, ConnectToAPI>();
            builder.Services.AddSingleton<IAllowedValuesService, AllowedValuesService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<CustomAuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetService<CustomAuthenticationStateProvider>());

            builder.Services.AddScoped<LoginViewModel>();
            builder.Services.AddScoped<RegisterViewModel>();
            builder.Services.AddScoped<LogoutViewModel>();

            builder.Services.AddScoped<CurrencyViewModel>();
            builder.Services.AddScoped<LanguageViewModel>();
            builder.Services.AddScoped<CountryViewModel>();
            builder.Services.AddScoped<CityViewModel>();
            builder.Services.AddScoped<HotelViewModel>();

            builder.Services.AddScoped<WeatherViewModel>();


            builder.Services.AddAuthorizationCore();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            Trace.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            return builder.Build();
        }
    }
}
