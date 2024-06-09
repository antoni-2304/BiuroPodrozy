using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiuroPodrozy.Data.Services.IServices
{
    public interface IAllowedValuesService
    {
        List<SelectListItem> GetAllowedValues(string name, Type type);
        List<string> GetAllowedValuesString(string name, Type type);
    }
}
