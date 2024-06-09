using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozyApp.ViewModels.Abstract;
using BiuroPodrozyApp.ViewModels.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiuroPodrozyApp.ViewModels
{
    public partial class CityViewModel : ACRUDViewModel<CityDTO>, ICRUDViewModel
    {
        public ICollection<CountryDTO> Countries { get; private set; } = new List<CountryDTO>();

        public CityViewModel(IConnectToAPI _biuroPodrozyService, NavigationManager _navigationManager)
            : base(_biuroPodrozyService, _navigationManager)
        {
            Model = new CityDTO();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(CityDTO), typeof(CityDTO.CityDTOMetaData)), typeof(CityDTO));
        }

        public override async Task Loaded()
            => Models = new ObservableCollection<CityDTO>(await BiuroPodrozyService.CitiesAllAsync());
        public void LoadItemNew()
            => Model = new CityDTO();
        public async Task LoadItemAsync(int id)
            => Model = await BiuroPodrozyService.CitiesGETAsync(id);

        public async Task LoadSelects()
        {
            await LoadCountries().InvokeAsync();
        }

        public EventCallback LoadCountries()
        {
            return EventCallback.Factory.Create(this, async () =>
            {
                if (Countries.Count == 0)
                {
                    Countries = await BiuroPodrozyService.CountriesAllAsync();
                }
            });
        }
        public Func<int, string> GetCountriesText => id => Countries.FirstOrDefault(c => c.IdCountry == id)?.CountryName ?? "";

        public EventCallback<EditContext> AddAsync()
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                if (editContext.Validate())
                {
                    await BiuroPodrozyService.CitiesPOSTAsync(Model);
                    NavigationManager.NavigateTo("/admin/city/list");
                }
            });
        }
        public EventCallback<EditContext> EditAsync(int id)
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                if (editContext.Validate())
                {
                    await BiuroPodrozyService.CitiesPUTAsync(id, Model);
                    NavigationManager.NavigateTo("/admin/city/list");
                }
            });
        }
        public EventCallback<EditContext> DeleteAsync(int id)
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                await BiuroPodrozyService.CitiesDELETEAsync(id);
                NavigationManager.NavigateTo("/admin/city/list");
            });
        }
    }
}
