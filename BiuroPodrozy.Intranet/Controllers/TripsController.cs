using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Intranet.ModelsForView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiuroPodrozy.Intranet.Controllers
{
	public class TripsController : Controller
	{
		protected ReferenceAPI BiuroPodrozyService;
		private readonly IAllowedValuesService _allowedValues;

		public TripsController(IConnectToAPI _biuroPodrozyService, IAllowedValuesService allowedValues)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
			_allowedValues = allowedValues;
		}

		// GET: Trips
		public async Task<IActionResult> Index(int id = 1)
		{
			var trips = new IndexTableViewModel<TripDTO>
			{
				Items = await BiuroPodrozyService.TripsAllAsync(),
				CurrentPage = id,
				ModelNameTranslatedList = "wycieczek",
				ModelNameTranslatedAdd = "wycieczkę"
			};
			return View(trips);
		}

		// GET: Trips/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var trip = new DetailsInfoViewModel<TripDTO>
			{
				Item = await BiuroPodrozyService.TripsGETAsync(id ?? 0),
			};

			if (trip.Item == null)
			{
				return NotFound();
			}

			return View(trip);
		}

		// GET: Trips/Create
		public async Task<IActionResult> Create()
		{
			ViewData["IdDestinationCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName");

			ViewData["TripType"] = _allowedValues.GetAllowedValues("TripType", typeof(TripDTO.TripDTOMetaData));

			return View();
		}

		// POST: Trips/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IdTrip, TripName, TripCode, TripCostPerAdult, TripCostPerChild, TripType, TripDescription, IdDestinationCity, IdHotel, Photos")] TripDTO trip)
		{
			if (ModelState.IsValid)
			{
				trip.DestinationCityName = (await BiuroPodrozyService.CitiesGETAsync(trip.IdDestinationCity)).CityName;
				await BiuroPodrozyService.TripsPOSTAsync(trip);
				return RedirectToAction(nameof(Index));
			}
			ViewData["IdDestinationCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName", trip.IdDestinationCity);
			ViewData["TripType"] = _allowedValues.GetAllowedValues("TripType", typeof(TripDTO.TripDTOMetaData));

			return View(trip);
		}

		// GET: Trips/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var trip = await BiuroPodrozyService.TripsGETAsync(id ?? 0);
			if (trip == null)
			{
				return NotFound();
			}
			ViewData["IdDestinationCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName");

			ViewData["TripType"] = _allowedValues.GetAllowedValues("TripType", typeof(TripDTO.TripDTOMetaData));

			return View(trip);
		}

		// POST: Trips/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdTrip, TripName, TripCode, TripCostPerAdult, TripCostPerChild, TripType, TripDescription, IdDestinationCity, IdHotel, Photos")] TripDTO trip)
		{
			if (id != trip.IdTrip)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				trip.DestinationCityName = (await BiuroPodrozyService.CitiesGETAsync(trip.IdDestinationCity)).CityName;
				await BiuroPodrozyService.TripsPUTAsync(id, trip);
				return RedirectToAction(nameof(Index));
			}

			ViewData["IdDestinationCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName", trip.IdDestinationCity);
			return View(trip);
		}

		// GET: Trips/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var trip = new DeleteItemViewModel<TripDTO>
			{
				Item = await BiuroPodrozyService.TripsGETAsync(id ?? 0),
			};
			if (trip.Item == null)
			{
				return NotFound();
			}

			return View(trip);
		}

		// POST: Trips/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await BiuroPodrozyService.TripsDELETEAsync(id);
			return RedirectToAction(nameof(Index));
		}


		public IActionResult UpdateHotelsByCity(string cityId)
		{
			List<HotelDTO> hotels = BiuroPodrozyService.HotelsAllAsync().Result.Where(h => h.IdCity == Int32.Parse(cityId)).ToList();
			SelectList hotelsList = new SelectList(hotels, "IdHotel", "HotelName", 0);
			return Json(hotelsList);
		}
	}
}
