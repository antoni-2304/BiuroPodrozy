using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozyApp.ViewModels.Abstract;
using BiuroPodrozyApp.ViewModels.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiuroPodrozyApp.ViewModels
{
    public partial class CountryViewModel : ACRUDViewModel<CountryDTO>, ICRUDViewModel
    {
        private readonly IAllowedValuesService AllowedValuesService;

        public List<SelectListItem> Continents { get; private set; }
        public ICollection<Currency> Currencies { get; private set; } = new List<Currency>();
        public ICollection<Language> Languages { get; private set; } = new List<Language>();
        public ICollection<CityDTO> Cities { get; private set; } = new List<CityDTO>();

        public CountryViewModel(IConnectToAPI _biuroPodrozyService, NavigationManager _navigationManager, IAllowedValuesService _allowedValuesService)
            : base(_biuroPodrozyService, _navigationManager)
        {
            AllowedValuesService = _allowedValuesService;
            Model = new CountryDTO();

            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(CountryDTO), typeof(CountryDTO.CountryDTOMetaData)), typeof(CountryDTO));

            Continents = AllowedValuesService.GetAllowedValues("Continent", typeof(CountryDTO.CountryDTOMetaData));

        }

        public override async Task Loaded()
           => Models = new ObservableCollection<CountryDTO>(await BiuroPodrozyService.CountriesAllAsync());
        public void LoadItemNew()
             => Model = new CountryDTO();
        public async Task LoadItemAsync(int id)
            => Model = await BiuroPodrozyService.CountriesGETAsync(id);


        public async Task LoadSelects()
        {
            await LoadCurrencies().InvokeAsync();
            await LoadLanguages().InvokeAsync();
            await LoadCities().InvokeAsync();
        }

        public EventCallback LoadCurrencies()
        {
            return EventCallback.Factory.Create(this, async () =>
            {
                if (Currencies.Count == 0)
                {
                    Currencies = await BiuroPodrozyService.CurrenciesAllAsync();
                }
            });
        }

        public EventCallback LoadLanguages()
        {
            return EventCallback.Factory.Create(this, async () =>
            {
                if (Languages.Count == 0)
                {
                    Languages = await BiuroPodrozyService.LanguagesAllAsync();
                }
            });
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

        public Func<int, string> GetCurrencyText => id => Currencies.FirstOrDefault(c => c.IdCurrency == id)?.CurrencyName ?? "";
        public Func<int, string> GetLanguageText => id => Languages.FirstOrDefault(c => c.IdLanguage == id)?.LanguageName ?? "";
        public Func<int?, string> GetCityText => id => Cities.FirstOrDefault(c => c.IdCity == id)?.CityName ?? "";

        public EventCallback<EditContext> AddAsync()
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                if (editContext.Validate())
                {
                    await BiuroPodrozyService.CountriesPOSTAsync(Model);
                    NavigationManager.NavigateTo("/admin/country/list");
                }
            });
        }
        public EventCallback<EditContext> EditAsync(int id)
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                if (editContext.Validate())
                {
                    await BiuroPodrozyService.CountriesPUTAsync(id, Model);
                    NavigationManager.NavigateTo("/admin/country/list");
                }
            });
        }
        public EventCallback<EditContext> DeleteAsync(int id)
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                await BiuroPodrozyService.CountriesDELETEAsync(id);
                NavigationManager.NavigateTo("/admin/country/list");
            });
        }
    }
}
