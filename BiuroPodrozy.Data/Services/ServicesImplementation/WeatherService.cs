using BiuroPodrozy.Data.Models;
using Newtonsoft.Json;

namespace BiuroPodrozy.Data.Services.ServicesImplementation
{
    public class WeatherService
    {
        public string GetWeatherIcon(string icon)
        {
            return $"https://openweathermap.org/img/wn/{icon}@2x.png";
        }
        public string ConvertToC(float temp)
        {
            return $"{double.Floor(temp - 273.15)}°C";
        }
        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            string baseUrl = "https://api.openweathermap.org/data/2.5/forecast";
            string apiKey = "";
            string url = $"{baseUrl}?q={city}&appid={apiKey}";

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
