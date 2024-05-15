using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    [QueryProperty(nameof(Order), "Order")]
    public partial class OrderDetailsPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private Order _order;

        [ObservableProperty]
        private Request _request;

        private DatabaseContext _context;

        public OrderDetailsPageViewModel(DatabaseContext context)
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
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "ClientId", Order.ClientId }
            };

            await Shell.Current.GoToAsync(nameof(OrdersInProcessPage), parameters);
        }

    }
}
