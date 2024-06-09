namespace BiuroPodrozy.Data.Services.IServices
{
    public interface ITokenService
    {
        public Task SaveTokenAsync(string accessToken, string refreshToken);
        public Task<string> GetAccessTokenAsync();
        public Task<string> GetRefreshTokenAsync();
    }
}
