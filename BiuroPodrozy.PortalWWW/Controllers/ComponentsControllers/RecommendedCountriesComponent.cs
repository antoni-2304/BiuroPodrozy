using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.PortalWWW.Controllers.ComponentsControllers
{
	public class RecommendedCountriesComponent : ViewComponent
	{
		private readonly ReferenceAPI BiuroPodrozyService;

		public RecommendedCountriesComponent(IConnectToAPI _biuroPodrozyService)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("RecommendedCountriesView", await BiuroPodrozyService.CountriesAllAsync());
		}
	}
}
