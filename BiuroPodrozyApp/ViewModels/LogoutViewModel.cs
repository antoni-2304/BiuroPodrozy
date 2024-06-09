using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Data.Utilities.Others;
using BiuroPodrozyApp.ViewModels.Abstract;
using Microsoft.AspNetCore.Components;

namespace BiuroPodrozyApp.ViewModels
{
    public class LogoutViewModel : AuthViewModel
    {
        public LogoutViewModel(IConnectToAPI _biuroPodrozyService, ITokenService tokenService, CustomAuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager)
            : base(_biuroPodrozyService, tokenService, authenticationStateProvider, navigationManager)
        {
        }

        public void Logout()
        {
            _authenticationStateProvider.MarkUserAsLoggedOut();
        }
    }
}
