using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MasterTool.UI.ViewModels.MasterViewModels
{
    [QueryProperty(nameof(Order),"Order")]
    public partial class OrderDetailsMasterPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private Order _order;

        [ObservableProperty]
        private Request _request;

        public ObservableCollection<Detail> OrderDetails { get; set; } = new();

        private DatabaseContext _context;
        public OrderDetailsMasterPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task LoadOrderData() => await LoadBaseRequest();
        private async Task LoadBaseRequest()
        {
            Request = await _context.GetItemByKeyAsync<Request>(Order.BaseRequestId);
        }

        [RelayCommand]
        public async Task GoBack() => await GoToOrdersPage();
        private async Task GoToOrdersPage()
        {
            await Shell.Current.GoToAsync(nameof(OrdersInProcessMasterPage));
        }

        [RelayCommand]
        public async Task FinishOrder() => await CompleteOrder();
        private async Task CompleteOrder()
        {
            Order.IsReady = true;
            await _context.UpdateItemAsync<Order>(Order);
            string date = DateTime.Today.ToString();
            var notification = new Notification($"Ваш заказ {Order.Id} готов",date,Order.BaseRequestId,Order.ClientId);
            await _context.AddItemAsync<Notification>(notification);
            await Shell.Current.DisplayAlert("Notification", "Уведомление отправлено клиенту", "OK");
        }

        [RelayCommand]
        public async Task GoToStorage()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"OrderId",Order.Id }
            };
            await Shell.Current.GoToAsync(nameof(StoragePage),parameters);
        }

        [RelayCommand]
        public async Task LoadOrderDetails()
        {
            var details = await _context.GetFileteredAsync<OrderDetail>(d => d.OrderId == Order.Id);
            foreach (var item in details)
            {
                var detail = (await _context.GetFileteredAsync<Detail>(d=>d.Id==item.DetailId)).FirstOrDefault();
                detail.Amount = item.Amount;
                OrderDetails.Add(detail);
            }
        }
    }
}
