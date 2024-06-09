using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Data.Utilities.Others;
using Blazing.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;

namespace BiuroPodrozyApp.ViewModels.Abstract
{
    public abstract class AuthViewModel : ViewModelBase
    {
        protected ReferenceAPI BiuroPodrozyService;
        protected NavigationManager _navigationManager;
        protected ITokenService _tokenService;
        protected CustomAuthenticationStateProvider _authenticationStateProvider;

        public AuthViewModel(IConnectToAPI _biuroPodrozyService, ITokenService tokenService, CustomAuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager)
        {
            BiuroPodrozyService = _biuroPodrozyService.Connect();
            _tokenService = tokenService;
            _authenticationStateProvider = authenticationStateProvider;
            _navigationManager = navigationManager;
        }
    }
}
