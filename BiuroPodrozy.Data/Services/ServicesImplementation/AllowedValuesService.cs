using BiuroPodrozy.Data.Services.IServices;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BiuroPodrozy.Data.Services.ServicesImplementation
{
    public class AllowedValuesService : IAllowedValuesService
    {
        public List<SelectListItem> GetAllowedValues(string propertyName, Type type)
        {
            var ListSelectItems = new List<SelectListItem>();
            var propertyInfo = type.GetProperty(propertyName);
            if (propertyInfo != null)
            {
                var allowedValuesAttribute = propertyInfo.GetCustomAttribute<AllowedValuesAttribute>();
                if (allowedValuesAttribute != null)
                {
                    foreach (var allowedValue in allowedValuesAttribute.Values)
                    {
                        ListSelectItems.Add(new SelectListItem() { Text = allowedValue.ToString(), Value = allowedValue.ToString() });
                    }
                    return ListSelectItems;
                }
            }

            return ListSelectItems;
        }

        public List<string> GetAllowedValuesString(string name, Type type)
        {
            throw new NotImplementedException();
        }
    }
}
