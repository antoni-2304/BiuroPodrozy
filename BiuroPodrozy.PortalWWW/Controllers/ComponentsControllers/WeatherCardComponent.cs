using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Data.Services.ServicesImplementation;
using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.PortalWWW.Controllers.ComponentsControllers
{
    public class WeatherCardComponent : ViewComponent
    {
        private readonly ReferenceAPI BiuroPodrozyService;
        private readonly WeatherService WeatherService;
        public WeatherCardComponent(IConnectToAPI _biuroPodrozyService, WeatherService _weatherService)
        {
            BiuroPodrozyService = _biuroPodrozyService.Connect();
            WeatherService = _weatherService;
        }
        public async Task<IViewComponentResult> InvokeAsync(CityDTO city)
        {
            return View("WeatherCardView", await WeatherService.GetWeatherAsync(city.CityName));
        }
    }
}
