using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Intranet.ModelsForView;
using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.Intranet.Controllers
{
	public class LanguagesController : Controller
	{
		protected ReferenceAPI BiuroPodrozyService;
		public LanguagesController(IConnectToAPI _biuroPodrozyService)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
		}

		// GET: Languages
		public async Task<IActionResult> Index(int id = 1)
		{
			var languages = new IndexTableViewModel<Language>
			{
				Items = await BiuroPodrozyService.LanguagesAllAsync(),
				CurrentPage = id,
				ModelNameTranslatedList = "języków",
				ModelNameTranslatedAdd = "język"
			};
			return View(languages);
		}

		// GET: Languages/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var language = new DetailsInfoViewModel<Language>
			{
				Item = await BiuroPodrozyService.LanguagesGETAsync(id ?? 0),
			};

			if (language.Item == null)
			{
				return NotFound();
			}

			return View(language);
		}

		// GET: Languages/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Languages/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IdLanguage,LanguageName,AbbrLanguageName")] Language language)
		{
			if (ModelState.IsValid)
			{
				await BiuroPodrozyService.LanguagesPOSTAsync(language);
				return RedirectToAction(nameof(Index));
			}
			return View(language);
		}


		// GET: Languages/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var language = await BiuroPodrozyService.LanguagesGETAsync(id ?? 0);
			if (language == null)
			{
				return NotFound();
			}
			return View(language);
		}

		// POST: Languages/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdLanguage,LanguageName,AbbrLanguageName")] Language language)
		{
			if (id != language.IdLanguage)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				await BiuroPodrozyService.LanguagesPUTAsync(id, language);
				return RedirectToAction(nameof(Index));
			}
			return View(language);
		}

		// GET: Languages/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var language = new DeleteItemViewModel<Language>
			{
				Item = await BiuroPodrozyService.LanguagesGETAsync(id ?? 0),
			};

			if (language.Item == null)
			{
				return NotFound();
			}

			return View(language);
		}

		// POST: Languages/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await BiuroPodrozyService.LanguagesDELETEAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}