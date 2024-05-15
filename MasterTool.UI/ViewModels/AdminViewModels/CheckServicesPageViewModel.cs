using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MasterTool.UI.ViewModels.AdminViewModels
{
    public partial class CheckServicesPageViewModel:ObservableObject
    {
        private DatabaseContext _context;
        public ObservableCollection<Service> Services { get; set; } = new();
        public CheckServicesPageViewModel(DatabaseContext context)
        {
            _context=context;
        }

        [RelayCommand]
        public async Task LoadAllServices() => await GetAllServices();
        private async Task GetAllServices()
        {
            var services = await _context.GetAllAsync<Service>();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Services.Clear();
                foreach (var service in services)
                {
                    Services.Add(service);
                }
            }
            );
        }

        [RelayCommand]
        public async Task AddNewService() => await GoToAddServicePage();
        private async Task GoToAddServicePage()
        {
            await Shell.Current.GoToAsync(nameof(AddNewServicePage));
        }

        [RelayCommand]
        public async Task GoBack() => await GoToHomePage();
        private async Task GoToHomePage()
        {
            await Shell.Current.GoToAsync(nameof(AdminHomePage));
        }
    }
}
