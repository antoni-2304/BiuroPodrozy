using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BiuroPodrozyApp.ViewModels.Interface
{
    public interface ICRUDViewModel
    {
        public Task LoadItemAsync(int id);
        public void LoadItemNew();
        public EventCallback<EditContext> AddAsync();
        public EventCallback<EditContext> EditAsync(int id);
        public EventCallback<EditContext> DeleteAsync(int id);
    }
}
