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
    public partial class LanguageViewModel : ACRUDViewModel<Language>, ICRUDViewModel
    {
        public LanguageViewModel(IConnectToAPI _biuroPodrozyService, NavigationManager _navigationManager)
            : base(_biuroPodrozyService, _navigationManager)
        {
            Model = new Language();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Language), typeof(Language.LanguageMetaData)), typeof(Language));
        }

        public override async Task Loaded()
           => Models = new ObservableCollection<Language>(await BiuroPodrozyService.LanguagesAllAsync());
        public void LoadItemNew()
            => Model = new Language();
        public async Task LoadItemAsync(int id)
            => Model = await BiuroPodrozyService.LanguagesGETAsync(id);

        public EventCallback<EditContext> AddAsync()
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                if (editContext.Validate())
                {
                    await BiuroPodrozyService.LanguagesPOSTAsync(Model);
                    NavigationManager.NavigateTo("/admin/language/list");
                }
            });
        }
        public EventCallback<EditContext> EditAsync(int id)
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                if (editContext.Validate())
                {
                    await BiuroPodrozyService.LanguagesPUTAsync(id, Model);
                    NavigationManager.NavigateTo("/admin/language/list");
                }
            });
        }
        public EventCallback<EditContext> DeleteAsync(int id)
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                await BiuroPodrozyService.LanguagesDELETEAsync(id);
                NavigationManager.NavigateTo("/admin/language/list");
            });
        }
    }
}
