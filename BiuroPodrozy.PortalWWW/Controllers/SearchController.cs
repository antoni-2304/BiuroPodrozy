using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.PortalWWW.Controllers
{
	public class SearchController : Controller
	{
		private readonly ReferenceAPI BiuroPodrozyService;

		public SearchController(IConnectToAPI _biuroPodrozyService)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
		}
		public async Task<IActionResult> Index(string targetLocation, string targetdate, string targetpeople)
		{
			if (targetLocation == null) return View(await BiuroPodrozyService.TripsAllAsync());
			else return View((await BiuroPodrozyService.TripsAllAsync()).Where(t => t.DestinationCityName == targetLocation));
		}

		public async Task<IActionResult> Details(int id)
		{
			var trip = await BiuroPodrozyService.TripsGETAsync(id);
			var city = await BiuroPodrozyService.CitiesGETAsync(trip.IdDestinationCity);
			var hotel = trip.IdHotel != null ? await BiuroPodrozyService.HotelsGETAsync((int)trip.IdHotel) : null;

			return View(new TripDetailsModel()
			{
				Trip = trip,
				City = city,
				Hotel = hotel
			});
		}

		public async Task<IActionResult> Filter(string element, string column, bool _checked)
		{
			IEnumerable<TripDTO> elements;

			if (_checked == true)
			{
				elements = (await BiuroPodrozyService.TripsAllAsync()).Where(t => t.GetType().GetProperty(column).GetValue(t).ToString().ToLowerInvariant() == element.ToLowerInvariant());
			}
			else
			{
				elements = (await BiuroPodrozyService.TripsAllAsync());
			}
			return ViewComponent("SearchCardComponent", elements);
		}
	}
}
