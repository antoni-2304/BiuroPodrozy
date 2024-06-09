using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Intranet.ModelsForView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiuroPodrozy.Intranet.Controllers
{
	public class CitiesController : Controller
	{
		protected ReferenceAPI BiuroPodrozyService;

		public CitiesController(IConnectToAPI _biuroPodrozyService)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
		}

		// GET: Cities
		public async Task<IActionResult> Index(int id = 1)
		{
			var cities = new IndexTableViewModel<CityDTO>
			{
				Items = await BiuroPodrozyService.CitiesAllAsync(),
				CurrentPage = id,
				ModelNameTranslatedList = "miast",
				ModelNameTranslatedAdd = "miasto"
			};
			return View(cities);
		}

		// GET: Cities/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var city = new DetailsInfoViewModel<CityDTO>
			{
				Item = await BiuroPodrozyService.CitiesGETAsync(id ?? 0),
			};


			if (city.Item == null)
			{
				return NotFound();
			}

			return View(city);
		}

		// GET: Cities/Create
		public async Task<IActionResult> Create()
		{
			ViewData["IdCountry"] = new SelectList(await BiuroPodrozyService.CountriesAllAsync(), "IdCountry", "CountryName");
			return View();
		}

		// POST: Cities/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IdCity,CityName,PostalCode,Population,IdCountry,WhoCreateId,CreationTime,LastModificationId,LastModificationTime,DeletionId,DeletionTime,IsValid,AuditDescription")] CityDTO city)
		{
			if (ModelState.IsValid)
			{
				city.CountryName = (await BiuroPodrozyService.CountriesGETAsync(city.IdCountry)).CountryName;
				await BiuroPodrozyService.CitiesPOSTAsync(city);
				return RedirectToAction(nameof(Index));
			}
			ViewData["IdCountry"] = new SelectList(await BiuroPodrozyService.CountriesAllAsync(), "IdCountry", "CountryName", city.IdCountry);
			return View(city);
		}

		// GET: Cities/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var city = await BiuroPodrozyService.CitiesGETAsync(id ?? 0);
			if (city == null)
			{
				return NotFound();
			}
			ViewData["IdCountry"] = new SelectList(await BiuroPodrozyService.CountriesAllAsync(), "IdCountry", "CountryName", city.IdCountry);
			return View(city);
		}

		// POST: Cities/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdCity,CityName,PostalCode,Population,IdCountry,WhoCreateId,CreationTime,LastModificationId,LastModificationTime,DeletionId,DeletionTime,IsValid,AuditDescription")] CityDTO city)
		{
			if (id != city.IdCity)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				city.CountryName = (await BiuroPodrozyService.CountriesGETAsync(city.IdCountry)).CountryName;
				await BiuroPodrozyService.CitiesPUTAsync(id, city);
				return RedirectToAction(nameof(Index));
			}
			ViewData["IdCountry"] = new SelectList(await BiuroPodrozyService.CountriesAllAsync(), "IdCountry", "CountryName", city.IdCountry);
			return View(city);
		}

		// GET: Cities/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var city = new DeleteItemViewModel<CityDTO>
			{
				Item = await BiuroPodrozyService.CitiesGETAsync(id ?? 0),
			};
			if (city.Item == null)
			{
				return NotFound();
			}

			return View(city);
		}

		// POST: Cities/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await BiuroPodrozyService.CitiesDELETEAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
