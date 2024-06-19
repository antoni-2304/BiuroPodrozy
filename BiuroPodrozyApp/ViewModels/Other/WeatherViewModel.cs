
using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Models;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Data.Services.ServicesImplementation;
using Blazing.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;

namespace BiuroPodrozyApp.ViewModels
{
    public partial class WeatherViewModel : ViewModelBase
    {
        protected ReferenceAPI BiuroPodrozyService;
        protected NavigationManager NavigationManager;
        public WeatherService WeatherService;

        [ObservableProperty]
        private WeatherData weatherData;
        [ObservableProperty]
        public int? selectedCityId;
        [ObservableProperty]
        public string selectedCityName;
        public Func<int?, string> GetCityText => id => Cities.FirstOrDefault(c => c.IdCity == id)?.CityName ?? "";
        public ICollection<CityDTO> Cities { get; private set; } = new List<CityDTO>();

        public WeatherViewModel(IConnectToAPI _biuroPodrozyService, NavigationManager navigationManager, WeatherService _weatherService)
        {
            BiuroPodrozyService = _biuroPodrozyService.Connect();
            NavigationManager = navigationManager;
            WeatherService = _weatherService;
        }

        public EventCallback LoadWeather()
        {
            return EventCallback.Factory.Create(this, async () =>
            {
                var city = await BiuroPodrozyService.CitiesGETAsync(SelectedCityId ?? 1);
                WeatherData = await WeatherService.GetWeatherAsync(city.CityName);
                NavigationManager.NavigateTo("/weather");
            });
        }
        public EventCallback LoadCities()
        {
            return EventCallback.Factory.Create(this, async () =>
            {
                if (Cities.Count == 0)
                {
                    Cities = await BiuroPodrozyService.CitiesAllAsync();
                }
            });
        }
    }
}
