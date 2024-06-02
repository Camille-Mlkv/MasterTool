using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    [QueryProperty(nameof(ClientId), "ClientId")]
    public partial class OrdersInProcessPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private int _clientId;

        private DatabaseContext _context;

        public ObservableCollection<Order> Orders { get; set; } = new();

        public OrdersInProcessPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task UpdateOrdersList() => await GetOrdersRequests();
        private async Task GetOrdersRequests()
        {
            var orders = await _context.GetFileteredAsync<Order>(o => o.ClientId == ClientId && o.IsReady == false &&o.IsRefusedByMaster==false);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Orders.Clear();
                foreach (var order in orders)
                    Orders.Add(order);
            });

        }

        [RelayCommand]
        async Task ShowDetails(Order order) => await GotoOrderDetailsPage(order);

        private async Task GotoOrderDetailsPage(Order order)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Order", order }
            };

            await Shell.Current.GoToAsync(nameof(OrderDetailsPage), parameters);
        }

        [RelayCommand]
        public async Task GoBack() => await GoToHomePage();
        private async Task GoToHomePage()
        {
            await Shell.Current.GoToAsync(nameof(ClientHomePage));
        }
    }
}
