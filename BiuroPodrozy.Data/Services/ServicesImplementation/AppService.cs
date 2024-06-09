using BiuroPodrozy.Data.Models;
using BiuroPodrozy.Data.Services.IServices;

namespace BiuroPodrozy.Data.Services.ServicesImplementation
{
    public class AppService : IAppService
    {
        public Task<string> AuthenticateUser(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}
