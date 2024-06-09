using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Intranet.ModelsForView;
using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.Intranet.Controllers
{
	public class CurrenciesController : Controller
	{
		protected ReferenceAPI BiuroPodrozyService;

		public CurrenciesController(IConnectToAPI _biuroPodrozyService)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
		}

		// GET: Currencies
		public async Task<IActionResult> Index(int id = 1)
		{
			var currencies = new IndexTableViewModel<Currency>
			{
				Items = await BiuroPodrozyService.CurrenciesAllAsync(),
				CurrentPage = id,
				ModelNameTranslatedList = "walut",
				ModelNameTranslatedAdd = "walutę"
			};
			return View(currencies);
		}

		// GET: Currencies/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var currency = new DetailsInfoViewModel<Currency>
			{
				Item = await BiuroPodrozyService.CurrenciesGETAsync(id ?? 0),
			};

			if (currency.Item == null)
			{
				return NotFound();
			}

			return View(currency);
		}

		// GET: Currencies/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Currencies/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IdCurrency,CurrencyName,CurrencySymbol,AbbrCurrency,WhoCreateId,CreationTime,LastModificationId,LastModificationTime,DeletionId,DeletionTime,IsValid,AuditDescription")] Currency currency)
		{
			if (ModelState.IsValid)
			{
				await BiuroPodrozyService.CurrenciesPOSTAsync(currency);
				return RedirectToAction(nameof(Index));
			}
			return View(currency);
		}

		// GET: Currencies/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var currency = await BiuroPodrozyService.CurrenciesGETAsync(id ?? 0);

			if (currency == null)
			{
				return NotFound();
			}
			return View(currency);
		}

		// POST: Currencies/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdCurrency,CurrencyName,CurrencySymbol,AbbrCurrency,WhoCreateId,CreationTime,LastModificationId,LastModificationTime,DeletionId,DeletionTime,IsValid,AuditDescription")] Currency currency)
		{
			if (id != currency.IdCurrency)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				await BiuroPodrozyService.CurrenciesPUTAsync(id, currency);
				return RedirectToAction(nameof(Index));
			}
			return View(currency);
		}

		// GET: Currencies/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var currency = new DeleteItemViewModel<Currency>
			{
				Item = await BiuroPodrozyService.CurrenciesGETAsync(id ?? 0),
			};

			if (currency.Item == null)
			{
				return NotFound();
			}

			return View(currency);
		}

		// POST: Currencies/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await BiuroPodrozyService.CurrenciesDELETEAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
