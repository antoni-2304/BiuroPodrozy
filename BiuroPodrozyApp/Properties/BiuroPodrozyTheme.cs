using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BiuroPodrozyApp.Properties
{
    public class BiuroPodrozyTheme : LayoutComponentBase
    {
        public static MudTheme Theme = new MudTheme()
        {
            Palette = new PaletteLight()
            {
                Primary = MudBlazor.Colors.Blue.Default,
                Secondary = MudBlazor.Colors.Yellow.Default
            },
            Typography = new Typography()
            {
                Default = new Default()
                {
                    FontFamily = new[] { "Open Sans" },
                },
                Button = new MudBlazor.Button()
                {
                    FontFamily = new[] { "Francois One" },
                },
                H4 = new H4()
                {
                    FontFamily = new[] { "Francois One" },
                },
                H5 = new H5()
                {
                    FontFamily = new[] { "Francois One" },
                },
                H6 = new H6()
                {
                    FontFamily = new[] { "Francois One" },
                },
            },
            LayoutProperties = new LayoutProperties()
            {
                DrawerWidthLeft = "260px",
                DrawerWidthRight = "300px"
            }
        };
    }
}
