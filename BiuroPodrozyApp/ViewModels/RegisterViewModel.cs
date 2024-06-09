using BiuroPodrozy.Data;
using BiuroPodrozy.Data.Models;
using BiuroPodrozy.Data.Services.IServices;
using BiuroPodrozy.Data.Utilities.Others;
using BiuroPodrozyApp.ViewModels.Abstract;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics;

namespace BiuroPodrozyApp.ViewModels
{
    public partial class RegisterViewModel : AuthViewModel
    {
        [ObservableProperty]
        private RegisterModel registerModel;

        public RegisterViewModel(IConnectToAPI _biuroPodrozyService, ITokenService tokenService, CustomAuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager)
        : base(_biuroPodrozyService, tokenService, authenticationStateProvider, navigationManager)
        {
            RegisterModel = new RegisterModel();
        }

        public EventCallback<EditContext> Submit()
        {
            return EventCallback.Factory.Create<EditContext>(this, async (editContext) =>
            {
                if (editContext.Validate())
                {
                    bool registerResponse = await BiuroPodrozyService.RegisterUserAsync(new RegisterModelDTO() { UserName = RegisterModel.UserName, Email = RegisterModel.Email, Password = RegisterModel.Password });
                    if (registerResponse)
                    {
                        var response = await BiuroPodrozyService.AuthenticateUserAsync(new LoginModelDTO() { Email = RegisterModel.Email, Password = RegisterModel.Password });
                        if (response.AccessToken != null)
                        {
                            await _tokenService.SaveTokenAsync(response.AccessToken, response.RefreshToken);
                            _authenticationStateProvider.MarkUserAsAuthenticated(response.AccessToken);
                            _navigationManager.NavigateTo("/");
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Błąd rejestracji", "Podane hasło lub e-mail nie spełniają wymagań", "Ok");
                    }

                }
                else
                {
                    Trace.WriteLine("Walidacja nie przeszła");
                    //ShowValidationError();
                }
            });
        }
    }
}
