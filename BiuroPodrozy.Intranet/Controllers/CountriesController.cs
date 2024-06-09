using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Intranet.ModelsForView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BiuroPodrozy.Intranet.Controllers
{
	public class CountriesController : Controller
	{
		protected ReferenceAPI BiuroPodrozyService;
		private readonly IAllowedValuesService _allowedValues;

		public CountriesController(IConnectToAPI _biuroPodrozyService, IAllowedValuesService allowedValues)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
			_allowedValues = allowedValues;
		}

		// GET: Countries
		public async Task<IActionResult> Index(int id = 1)
		{
			var cities = new IndexTableViewModel<CountryDTO>
			{
				Items = await BiuroPodrozyService.CountriesAllAsync(),
				CurrentPage = id,
				ModelNameTranslatedList = "krajów",
				ModelNameTranslatedAdd = "kraj"
			};
			return View(cities);
		}

		// GET: Countries/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var country = new DetailsInfoViewModel<CountryDTO>
			{
				Item = await BiuroPodrozyService.CountriesGETAsync(id ?? 0),
			};

			if (country.Item == null)
			{
				return NotFound();
			}

			return View(country);
		}

		// GET: Countries/Create
		public async Task<IActionResult> Create()
		{
			ViewData["IdCapitalCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName");
			ViewData["IdCurrency"] = new SelectList(await BiuroPodrozyService.CurrenciesAllAsync(), "IdCurrency", "CurrencyName");
			ViewData["IdLanguage"] = new SelectList(await BiuroPodrozyService.LanguagesAllAsync(), "IdLanguage", "LanguageName");

			ViewData["Continent"] = _allowedValues.GetAllowedValues("Continent", typeof(CountryDTO.CountryDTOMetaData));

			return View();
		}

		// POST: Countries/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IdCountry,CountryName,AbbrCountryName,Continent,Population,CountrySize,PhoneCode,IdCurrency,IdLanguage,IdCapitalCity,WhoCreateId,CreationTime,LastModificationId,LastModificationTime,DeletionId,DeletionTime,IsValid,AuditDescription,Photos")] CountryDTO country)
		{
			if (ModelState.IsValid)
			{
				country.CurrencyName = (await BiuroPodrozyService.CurrenciesGETAsync(country.IdCurrency)).CurrencyName;
				country.LanguageName = (await BiuroPodrozyService.LanguagesGETAsync(country.IdLanguage)).LanguageName;
				country.CapitalCityName = (await BiuroPodrozyService.CitiesGETAsync(country.IdCapitalCity ?? -1)).CityName;
				await BiuroPodrozyService.CountriesPOSTAsync(country);
				return RedirectToAction(nameof(Index));
			}
			ViewData["IdCapitalCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName", country.IdCapitalCity);
			ViewData["IdCurrency"] = new SelectList(await BiuroPodrozyService.CurrenciesAllAsync(), "IdCurrency", "AbbrCurrency", country.IdCurrency);
			ViewData["IdLanguage"] = new SelectList(await BiuroPodrozyService.LanguagesAllAsync(), "IdLanguage", "AbbrLanguageName", country.IdLanguage);
			return View(country);
		}

		// GET: Countries/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var country = await BiuroPodrozyService.CountriesGETAsync(id ?? 0);
			if (country == null)
			{
				return NotFound();
			}
			ViewData["IdCapitalCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName", country.IdCapitalCity);
			ViewData["IdCurrency"] = new SelectList(await BiuroPodrozyService.CurrenciesAllAsync(), "IdCurrency", "AbbrCurrency", country.IdCurrency);
			ViewData["IdLanguage"] = new SelectList(await BiuroPodrozyService.LanguagesAllAsync(), "IdLanguage", "AbbrLanguageName", country.IdLanguage);

			ViewData["Continent"] = _allowedValues.GetAllowedValues("Continent", typeof(CountryDTO.CountryDTOMetaData));

			return View(country);
		}

		// POST: Countries/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdCountry,CountryName,AbbrCountryName,Continent,Population,CountrySize,PhoneCode,IdCurrency,IdLanguage,IdCapitalCity,WhoCreateId,CreationTime,LastModificationId,LastModificationTime,DeletionId,DeletionTime,IsValid,AuditDescription,Photos")] CountryDTO country)
		{
			if (id != country.IdCountry)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				country.CurrencyName = (await BiuroPodrozyService.CurrenciesGETAsync(country.IdCurrency)).CurrencyName;
				country.LanguageName = (await BiuroPodrozyService.LanguagesGETAsync(country.IdLanguage)).LanguageName;
				country.CapitalCityName = (await BiuroPodrozyService.CitiesGETAsync(country.IdCapitalCity ?? -1)).CityName;
				await BiuroPodrozyService.CountriesPUTAsync(id, country);
				return RedirectToAction(nameof(Index));
			}

			ViewData["IdCapitalCity"] = new SelectList(await BiuroPodrozyService.CitiesAllAsync(), "IdCity", "CityName", country.IdCapitalCity);
			ViewData["IdCurrency"] = new SelectList(await BiuroPodrozyService.CurrenciesAllAsync(), "IdCurrency", "AbbrCurrency", country.IdCurrency);
			ViewData["IdLanguage"] = new SelectList(await BiuroPodrozyService.LanguagesAllAsync(), "IdLanguage", "AbbrLanguageName", country.IdLanguage);
			return View(country);
		}

		// GET: Countries/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var country = new DeleteItemViewModel<CountryDTO>
			{
				Item = await BiuroPodrozyService.CountriesGETAsync(id ?? 0),
			};
			if (country.Item == null)
			{
				return NotFound();
			}

			return View(country);
		}

		// POST: Countries/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await BiuroPodrozyService.CountriesDELETEAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
