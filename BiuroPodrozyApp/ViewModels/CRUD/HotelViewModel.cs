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
    public partial class HotelViewModel : ACRUDViewModel<HotelDTO>, ICRUDViewModel
    {
        public ICollection<CityDTO> Cities { get; private set; } = new List<CityDTO>();

        public HotelViewModel(IConnectToAPI _biuroPodrozyService, NavigationManager _navigationManager)
            : base(_biuroPodrozyService, _navigationManager)
        {
            Model = new HotelDTO();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(HotelDTO), typeof(HotelDTO.HotelDTOMetaData)), typeof(HotelDTO));
        }

        public override async Task Loaded()
            => Models = new ObservableCollection<HotelDTO>(await BiuroPodrozyService.HotelsAllAsync());
        public void LoadItemNew()
            => Model = new HotelDTO();
        public async Task LoadItemAsync(int id)
            => Model = await BiuroPodrozyService.HotelsGETAsync(id);

        public async Task LoadSelects()
        {
            await LoadCities().InvokeAsync();
        }

        public EventCallback LoadCities()
        {
            return EventCallback.Factory.Create(this, async () =>
            {
                if (Cities.Count == 0)
                {
                    Cities = await BiuroPodrozyService.CitiesAllAsync();
                }
            });
        }
        public Func<int, string> GetCitiesText => id => Cities.FirstOrDefault(c => c.IdCity == id)?.CityName ?? "";

        public EventCallback<EditContext> AddAsync()
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                if (editContext.Validate())
                {
                    await BiuroPodrozyService.HotelsPOSTAsync(Model);
                    NavigationManager.NavigateTo("/admin/hotel/list");
                }
            });
        }
        public EventCallback<EditContext> EditAsync(int id)
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                if (editContext.Validate())
                {
                    await BiuroPodrozyService.HotelsPUTAsync(id, Model);
                    NavigationManager.NavigateTo("/admin/hotel/list");
                }
            });
        }
        public EventCallback<EditContext> DeleteAsync(int id)
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                await BiuroPodrozyService.HotelsDELETEAsync(id);
                NavigationManager.NavigateTo("/admin/hotel/list");
            });
        }
    }
}
