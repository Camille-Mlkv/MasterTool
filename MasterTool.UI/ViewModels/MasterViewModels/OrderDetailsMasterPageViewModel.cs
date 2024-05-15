using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterTool.UI.Pages.MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.MasterViewModels
{
    [QueryProperty(nameof(Order),"Order")]
    public partial class OrderDetailsMasterPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private Order _order;

        [ObservableProperty]
        private Request _request;

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
    }
}
