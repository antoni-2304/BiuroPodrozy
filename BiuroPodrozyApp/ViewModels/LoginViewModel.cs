using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Models;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Data.Utilities.Others;
using BiuroPodrozyApp.ViewModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BiuroPodrozyApp.ViewModels
{
    public partial class LoginViewModel : AuthViewModel
    {
        [ObservableProperty]
        private LoginModel loginModel;

        public LoginViewModel(IConnectToAPI _biuroPodrozyService, ITokenService tokenService, CustomAuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager) :
        base(_biuroPodrozyService, tokenService, authenticationStateProvider, navigationManager)
        {
            LoginModel = new LoginModel();
        }

        public EventCallback<EditContext> Submit()
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                var response = await BiuroPodrozyService.AuthenticateUserAsync(new LoginModelDTO() { Email = LoginModel.Email, Password = LoginModel.Password });
                if (response.AccessToken != null)
                {
                    await _tokenService.SaveTokenAsync(response.AccessToken, response.RefreshToken);
                    _authenticationStateProvider.MarkUserAsAuthenticated(response.AccessToken);
                    await App.Current.MainPage.DisplayAlert("Sukces", "ok", "ok");
                    _navigationManager.NavigateTo("/");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Błąd logowania", "Nie znaleziono użytkownika o podanych danych", "Ok");
                }
            });
        }
    }
}
