using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterTool.UI.Pages.ClientPages;
using MasterTool.UI.Pages.MasterPages;
using System.Collections.ObjectModel;

namespace MasterTool.UI.ViewModels.MasterViewModels
{
    public partial class OrdersInProcessMasterPageViewModel:ObservableObject
    {
        private DatabaseContext _context;
        public ObservableCollection<Order> Orders { get; set; } = new();
        public OrdersInProcessMasterPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task LoadOrders() => await GetNotReadyOrders();
        private async Task GetNotReadyOrders()
        {
            var orders = await _context.GetFileteredAsync<Order>(o => o.MasterId == CurrentUser.CurrentMaster.Id && o.IsReady == false);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Orders.Clear();
                foreach (var order in orders)
                    Orders.Add(order);
            });
        }

        [RelayCommand]
        public async Task GoBack() => await GoToHomePage();
        private async Task GoToHomePage()
        {
            await Shell.Current.GoToAsync(nameof(MasterHomePage));
        }

        [RelayCommand]
        public async Task ShowDetails(Order order) => await GoToDetailsPage(order);
        private async Task GoToDetailsPage(Order order)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Order", order }
            };

            await Shell.Current.GoToAsync(nameof(OrderDetailsMasterPage),parameters);
        }
    }
}
