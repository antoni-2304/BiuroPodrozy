using BiuroPodrozy.Data.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace BiuroPodrozy.Data.Services.ServicesImplementation
{
    public class HttpOnlyTokenService : ITokenService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpOnlyTokenService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SaveTokenAsync(string accessToken, string refreshToken)
        {
            var httpResponse = _httpContextAccessor.HttpContext.Response;

            httpResponse.Cookies.Append("AccessToken", accessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                Expires = DateTimeOffset.UtcNow.AddMinutes(30)
            });

            httpResponse.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                Expires = DateTimeOffset.UtcNow.AddMinutes(30)
            });
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var httpRequest = _httpContextAccessor.HttpContext.Request;

            return httpRequest.Cookies["AccessToken"];
        }

        public async Task<string> GetRefreshTokenAsync()
        {
            var httpRequest = _httpContextAccessor.HttpContext.Request;

            return httpRequest.Cookies["RefreshToken"];
        }
    }
}
