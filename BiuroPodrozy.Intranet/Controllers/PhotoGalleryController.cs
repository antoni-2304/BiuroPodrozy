using Microsoft.AspNetCore.Mvc;

namespace BiuroPodrozy.Intranet.Controllers
{
	public class PhotoGalleryController : Controller
	{
		public IActionResult DeletePhoto(string photos, string photo)
		{
			photos = photos.Replace(photo, "");
			ICollection<string> photosList = photos.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
			return ViewComponent("PhotosGalleryComponent", photosList);
		}

		public IActionResult AddPhoto(string photos, string photo)
		{
			photos += ",Photos/" + photo;
			ICollection<string> photosList = photos.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
			return ViewComponent("PhotosGalleryComponent", photosList);
		}
	}
}
