using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.PortalWWW.Controllers.ComponentsControllers
{
	public class NavbarLinksComponent : ViewComponent
	{
		private readonly ReferenceAPI BiuroPodrozyService;

		public NavbarLinksComponent(IConnectToAPI _biuroPodrozyService)
		{
			BiuroPodrozyService = _biuroPodrozyService.Connect();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("NavbarLinksView", await BiuroPodrozyService.PagesAllAsync());
		}
	}
}
