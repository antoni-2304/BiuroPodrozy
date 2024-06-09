using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.Intranet.Controllers
{
	public class SiteController : Controller
	{
		protected ReferenceAPI BiuroPodrozyService;

		public SiteController(IConnectToAPI _biuroPodrozyService)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
		}

		// GET: Site
		public async Task<IActionResult> Index()
		{
			return View((await BiuroPodrozyService.SitesAllAsync()).FirstOrDefault());
		}

		// GET: Site/Edit/5
		public async Task<IActionResult> Edit()
		{
			return View((await BiuroPodrozyService.SitesAllAsync()).FirstOrDefault());
		}

		// POST: Site/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit([Bind("IdSite,Title,Description,Author,Tag")] Site site, IFormFile LogoUploaded)
		{
			site.Logo = new Uri("Icons/" + LogoUploaded.FileName, UriKind.Relative);

			ModelState.Clear();
			if (TryValidateModel(site))
			{
				await BiuroPodrozyService.SitesPUTAsync(site.IdSite, site);
				return RedirectToAction(nameof(Index));
			}
			return View(site);
		}
	}
}
