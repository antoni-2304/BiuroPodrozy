using BiuroPodrozy.Data.Services.IServices;
using Microsoft.Maui.Storage;


namespace BiuroPodrozy.Data.Services.ServicesImplementation
{
    public class TokenService : ITokenService
    {
        public async Task<string> GetAccessTokenAsync()
        {
            return await SecureStorage.GetAsync("accessToken");
        }

        public async Task<string> GetRefreshTokenAsync()
        {
            return await SecureStorage.GetAsync("refreshToken");
        }

        public async Task SaveTokenAsync(string accessToken, string refreshToken)
        {
            await SecureStorage.Default.SetAsync("AccessToken", accessToken);
            await SecureStorage.Default.SetAsync("RefreshToken", refreshToken);
        }
    }
}
