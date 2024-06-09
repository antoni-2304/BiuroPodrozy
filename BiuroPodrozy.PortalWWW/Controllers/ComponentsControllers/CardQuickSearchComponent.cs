using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.PortalWWW.Controllers.ComponentsControllers
{
	public class CardQuickSearchComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("CardQuickSearchView");
		}
	}
}
