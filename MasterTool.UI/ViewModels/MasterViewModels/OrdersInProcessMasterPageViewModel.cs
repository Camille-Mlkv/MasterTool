using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var orders = await _context.GetFileteredAsync<Order>(o => o.MasterId == CurrentUser.CurrentMaster.Id && o.IsReady == false && o.IsRefusedByMaster==false);
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

        [RelayCommand]
        public async Task RejectOrder(Order order)
        {
            order.IsRefusedByMaster = true;
            await _context.UpdateItemAsync<Order>(order);

            int requestId = order.BaseRequestId;
            var request=await _context.GetItemByKeyAsync<Request>(requestId);
            request.IsOrder = false;
            await _context.UpdateItemAsync<Request>(request);

            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd HH:mm");
            var notification = new Notification($"Your order #{order.Id} has been cancelled due to technical issues, request is still available.", date, requestId, order.ClientId,true);
            await _context.AddItemAsync<Notification>(notification);
        }
    }
}
