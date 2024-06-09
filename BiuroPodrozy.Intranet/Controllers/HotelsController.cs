using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Intranet.ModelsForView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiuroPodrozy.Intranet.Controllers
{
	public class HotelsController : Controller
	{
		protected ReferenceAPI BiuroPodrozyService;

		public HotelsController(IConnectToAPI _biuroPodrozyService)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
		}

		// GET: Hotels
		public async Task<IActionResult> Index(int id = 1)
		{
			var hotels = new IndexTableViewModel<HotelDTO>
			{
				Items = await BiuroPodrozyService.HotelsAllAsync(),
				CurrentPage = id,
				ModelNameTranslatedList = "hoteli",
				ModelNameTranslatedAdd = "hotel"
			};
			return View(hotels);
		}

		// GET: Hotels/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var hotel = new DetailsInfoViewModel<HotelDTO>
			{
				Item = await BiuroPodrozyService.HotelsGETAsync(id ?? 0),
			};

			if (hotel == null)
			{
				return NotFound();
			}

			return View(hotel);
		}

		// GET: Hotels/Create
		public async Task<IActionResult> Create()
		{
			ViewData["IdCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName");
			return View();
		}

		// POST: Hotels/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IdHotel,HotelName,HotelStars,HotelRating,Phone,Email,Description,HotelPricePerUnit,Street,HomeNr,Latitude,Longitude,IdCity,Photos")] HotelDTO hotel)
		{
			if (ModelState.IsValid)
			{
				hotel.CityName = (await BiuroPodrozyService.CitiesGETAsync(hotel.IdCity)).CityName;
				await BiuroPodrozyService.HotelsPOSTAsync(hotel);
				return RedirectToAction(nameof(Index));
			}

			ViewData["IdCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName", hotel.IdCity);
			return View(hotel);
		}

		// GET: Hotels/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var hotel = await BiuroPodrozyService.HotelsGETAsync(id ?? 0);

			if (hotel == null)
			{
				return NotFound();
			}
			ViewData["IdCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName", hotel.IdCity);
			return View(hotel);
		}

		// POST: Hotels/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdHotel,HotelName,HotelStars,HotelRating,Phone,Email,Description,HotelPricePerUnit,Street,HomeNr,CityName,Latitude,Longitude,IdCity,Photos")] HotelDTO hotel)
		{
			if (id != hotel.IdHotel)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				hotel.CityName = (await BiuroPodrozyService.CitiesGETAsync(hotel.IdCity)).CityName;
				await BiuroPodrozyService.HotelsPUTAsync(id, hotel);
				return RedirectToAction(nameof(Index));
			}
			ViewData["IdCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName", hotel.IdCity);
			return View(hotel);
		}

		// GET: Hotels/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var hotel = new DeleteItemViewModel<HotelDTO>
			{
				Item = await BiuroPodrozyService.HotelsGETAsync(id ?? 0),
			};
			if (hotel.Item == null)
			{
				return NotFound();
			}

			return View(hotel);
		}

		// POST: Hotels/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await BiuroPodrozyService.HotelsDELETEAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
