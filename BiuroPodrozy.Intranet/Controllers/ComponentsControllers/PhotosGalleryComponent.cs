using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.Intranet.Controllers.ComponentsControllers
{
	public class PhotosGalleryComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(ICollection<string> photos)
		{
			return View("PhotoGalleryView", photos);
		}


	}
}
