using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using Blazing.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace BiuroPodrozyApp.ViewModels
{
    public partial class FetchDataViewModel : ViewModelBase
    {
        protected ReferenceAPI BiuroPodrozyService;

        public FetchDataViewModel(IConnectToAPI _biuroPodrozyService)
        {
            BiuroPodrozyService = _biuroPodrozyService.Connect();
        }

        [ObservableProperty]
        private ObservableCollection<Currency> _currencies = new();

        public override async Task Loaded()
           => Currencies = new ObservableCollection<Currency>(await BiuroPodrozyService.CurrenciesAllAsync());

    }
}
