using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterTool.UI.Pages.AdminPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.AdminViewModels
{
    public partial class AddNewServicePageViewModel:ObservableObject
    {
        [ObservableProperty]
        private Service _service;

        private DatabaseContext _context;

        public AddNewServicePageViewModel(DatabaseContext context)
        {
            _context = context;
            Service = new Service();
        }

        [RelayCommand]
        public async Task CreateService() => await SaveNewService();

        private async Task SaveNewService()
        {
            await _context.AddItemAsync<Service>(Service);
            await Shell.Current.DisplayAlert("Notification", "Сервис успешно создан", "OK");

            await Shell.Current.GoToAsync(nameof(AdminHomePage));
        }
    }
}
