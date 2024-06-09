using Microsoft.AspNetCore.Http;

namespace BiuroPodrozy.Data.Utilities.Files
{
    public static class FileUtilities
    {
        public static string UploadFile(IFormFile logoUploaded)
        {
            string ImageName = Guid.NewGuid().ToString() + "_logo" + Path.GetExtension(logoUploaded.FileName);
            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Assets/Images/Icons/", ImageName);

            if (MoveToFolder(logoUploaded, SavePath))
            {
                return ImageName;
            }
            return "";
        }

        public static bool MoveToFolder(IFormFile file, string savePath)
        {
            using (var stream = new FileStream(savePath, FileMode.OpenOrCreate))
            {
                file.CopyTo(stream);
                return true;
            }
        }
    }
}
