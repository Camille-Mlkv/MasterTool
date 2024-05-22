using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterToolDomain.Entities;
using System.Collections.ObjectModel;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    public partial class ClientReadyOrdersPageViewModel:ObservableObject
    {
        private DatabaseContext _context;
        public ObservableCollection<Order> Orders { get; set; } = new();
        public ClientReadyOrdersPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task LoadReadyOrders() => await GetReadyOrders();
        private async Task GetReadyOrders()
        {
            var orders = await _context.GetFileteredAsync<Order>(o => o.ClientId == CurrentUser.CurrentClient.Id && o.IsReady == true);
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
            await Shell.Current.GoToAsync(nameof(ClientHomePage));
        }

        //Оставлять отзыв только полученному товару, то есть оплаченному
        //Добавить заказу поле оплачен

        [RelayCommand]
        public async Task LeaveFeedback(Order order)
        {
            //if(!order.IsPaid)
            //{
            //    await Shell.Current.DisplayAlert("Notification", "Отзыв можно оставить к оплаченному заказу", "OK");
            //    return;
            //}
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"OrderId",order.Id }
            };
            await Shell.Current.GoToAsync(nameof(FeedbackPage),parameters);
        }
    }
}
