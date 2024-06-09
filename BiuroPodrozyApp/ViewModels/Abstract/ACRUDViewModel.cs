using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using Blazing.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace BiuroPodrozyApp.ViewModels.Abstract
{
    public partial class ACRUDViewModel<T> : ViewModelBase
    {
        protected ReferenceAPI BiuroPodrozyService;
        protected NavigationManager NavigationManager;

        [ObservableProperty]
        private T _model;
        [ObservableProperty]
        private ObservableCollection<T> _models = new();
        public ACRUDViewModel(IConnectToAPI _biuroPodrozyService, NavigationManager navigationManager)
        {
            BiuroPodrozyService = _biuroPodrozyService.Connect();
            NavigationManager = navigationManager;
        }
    }
}
