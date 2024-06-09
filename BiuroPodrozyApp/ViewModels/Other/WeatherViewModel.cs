
using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Models;
using BiuroPodrozy.Data.Services.IServices;
using Blazing.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BiuroPodrozyApp.ViewModels
{
    public partial class WeatherViewModel : ViewModelBase
    {
        protected ReferenceAPI BiuroPodrozyService;
        protected NavigationManager NavigationManager;

        [ObservableProperty]
        private WeatherData weatherData;
        public ICollection<CityDTO> Cities { get; private set; } = new List<CityDTO>();

        public WeatherViewModel(IConnectToAPI _biuroPodrozyService, NavigationManager navigationManager)
        {
            BiuroPodrozyService = _biuroPodrozyService.Connect();
            NavigationManager = navigationManager;
        }

        public EventCallback LoadWeather()
        {
            return EventCallback.Factory.Create(this, async () =>
            {
                WeatherData = await this.GetWeatherAsync("Warszawa", "pl");
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
        public Func<int?, string> GetCityText => id => Cities.FirstOrDefault(c => c.IdCity == id)?.CityName ?? "";

        public async Task<WeatherData> GetWeatherAsync(string city, string country)
        {
            string baseUrl = "https://api.openweathermap.org/data/2.5/weather";
            string apiKey = "3aacf7549d4954711299501e488b45da";
            string url = $"{baseUrl}?q={city},{country}&appid={apiKey}";

            using var response = await new HttpClient().GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                using (var jsonReader = new JsonTextReader(new StringReader(json)))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<WeatherData>(jsonReader);
                }
            }
            else
            {
                throw new Exception($"Failed to get weather data: {response.StatusCode}");
            }

        }
    }
}
