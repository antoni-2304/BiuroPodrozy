using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.PortalWWW.Controllers.ComponentsControllers
{
	public class SearchCardComponent : ViewComponent
	{
		private readonly ReferenceAPI BiuroPodrozyService;

		public SearchCardComponent(IConnectToAPI _biuroPodrozyService)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
		}
		public async Task<IViewComponentResult> InvokeAsync(IEnumerable<TripDTO> trips)
		{
			return View("SearchCardView", trips);
		}
	}
}
