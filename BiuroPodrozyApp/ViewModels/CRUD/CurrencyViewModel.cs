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
    public partial class CurrencyViewModel : ACRUDViewModel<Currency>, ICRUDViewModel
    {
        public CurrencyViewModel(IConnectToAPI _biuroPodrozyService, NavigationManager _navigationManager)
            : base(_biuroPodrozyService, _navigationManager)
        {
            Model = new Currency();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Currency), typeof(Currency.CurrencyMetaData)), typeof(Currency));
        }

        public override async Task Loaded()
           => Models = new ObservableCollection<Currency>(await BiuroPodrozyService.CurrenciesAllAsync());
        public void LoadItemNew()
            => Model = new Currency();
        public async Task LoadItemAsync(int id)
            => Model = await BiuroPodrozyService.CurrenciesGETAsync(id);

        public EventCallback<EditContext> AddAsync()
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                if (editContext.Validate())
                {
                    await BiuroPodrozyService.CurrenciesPOSTAsync(Model);
                    NavigationManager.NavigateTo("/admin/currency/list");
                }
            });
        }
        public EventCallback<EditContext> EditAsync(int id)
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                if (editContext.Validate())
                {
                    await BiuroPodrozyService.CurrenciesPUTAsync(id, Model);
                    NavigationManager.NavigateTo("/admin/currency/list");
                }
            });
        }
        public EventCallback<EditContext> DeleteAsync(int id)
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                await BiuroPodrozyService.CurrenciesDELETEAsync(id);
                NavigationManager.NavigateTo("/admin/currency/list");
            });
        }
    }
}
