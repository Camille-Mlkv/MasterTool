using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MasterTool.UI.ViewModels.MasterViewModels
{
    public partial class ServicesPageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        public ObservableCollection<Service> Services { get; set; } = new();
        public ServicesPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task UpdateServicesList() => await GetServices();
        private async Task GetServices()
        {
            var services = await _context.GetAllAsync<Service>();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Services.Clear();
                foreach (var s in services)
                    Services.Add(s);
            });
        }

        [RelayCommand]
        public async Task GoBack() => await GoToHomePage();
        private async Task GoToHomePage()
        {
            await Shell.Current.GoToAsync(nameof(MasterHomePage));
        }

        [RelayCommand]
        public async Task ShowClientsRequests(Service service) => await GoToClientsRequests(service);
        private async Task GoToClientsRequests(Service service)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Service", service }
            };
            await Shell.Current.GoToAsync(nameof(ClientsRequestsPage), parameters);

        }

    }
}
