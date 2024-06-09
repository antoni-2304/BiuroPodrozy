using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Intranet.ModelsForView;
using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.Intranet.Controllers
{
	public class PagesController : Controller
	{
		protected ReferenceAPI BiuroPodrozyService;
		private readonly IAllowedValuesService _allowedValues;

		public PagesController(IConnectToAPI _biuroPodrozyService, IAllowedValuesService allowedValues)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
			_allowedValues = allowedValues;
		}

		// GET: Pages
		public async Task<IActionResult> Index(int id = 1)
		{
			var pages = new IndexTableViewModel<Page>
			{
				Items = await BiuroPodrozyService.PagesAllAsync(),
				CurrentPage = id,
				ModelNameTranslatedList = "stron",
				ModelNameTranslatedAdd = "stronę"
			};
			return View(pages);
		}

		// GET: Pages/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var page = new DetailsInfoViewModel<Page>
			{
				Item = await BiuroPodrozyService.PagesGETAsync(id ?? 0),
			};

			if (page.Item == null)
			{
				return NotFound();
			}

			return View(page);
		}

		// GET: Pages/Create
		public IActionResult Create()
		{
			ViewData["AccessLevel"] = _allowedValues.GetAllowedValues("AccessLevel", typeof(Page.PageMetaData));
			return View();
		}

		// POST: Pages/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("IdPage,PageTitle,PageIndexRelativeURL,Author,AccessLevel,IncludeInNavbar")] Page page)
		{
			if (ModelState.IsValid)
			{
				await BiuroPodrozyService.PagesPOSTAsync(page);
				return RedirectToAction(nameof(Index));
			}
			return View(page);
		}

		// GET: Pages/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var page = await BiuroPodrozyService.PagesGETAsync(id ?? 0);
			if (page == null)
			{
				return NotFound();
			}
			ViewData["AccessLevel"] = _allowedValues.GetAllowedValues("AccessLevel", typeof(Page.PageMetaData));
			return View(page);
		}

		// POST: Pages/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("IdPage,PageTitle,PageIndexRelativeURL,Author,AccessLevel,IncludeInNavbar")] Page page)
		{
			if (id != page.IdPage)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				await BiuroPodrozyService.PagesPUTAsync(id, page);
				return RedirectToAction(nameof(Index));
			}
			return View(page);
		}

		// GET: Pages/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var page = new DeleteItemViewModel<Page>
			{
				Item = await BiuroPodrozyService.PagesGETAsync(id ?? 0),
			};
			if (page.Item == null)
			{
				return NotFound();
			}

			return View(page);
		}

		// POST: Pages/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await BiuroPodrozyService.PagesDELETEAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
