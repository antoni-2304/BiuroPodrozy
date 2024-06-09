using BiuroPodrozy.Data.Models;

namespace BiuroPodrozy.Data.Services.IServices
{
    internal interface IAppService
    {
        public Task<string> AuthenticateUser(LoginModel loginModel);
    }
}
