using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.FileProviders;

namespace BiuroPodrozyApp.Custom
{
    public class CustomFilesBlazorWebView : BlazorWebView
    {
        public override IFileProvider CreateFileProvider(string contentRootDir)
        {
            var lPhysicalFiles = new PhysicalFileProvider(FileSystem.Current.AppDataDirectory);
            return new CompositeFileProvider(lPhysicalFiles, base.CreateFileProvider(contentRootDir));
        }
    }
}