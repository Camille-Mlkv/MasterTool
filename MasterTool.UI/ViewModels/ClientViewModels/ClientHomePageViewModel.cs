using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    public partial class ClientHomePageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        public ClientHomePageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task GetPersonalData() => await GoToPersonalDataPage();

        private async Task GoToPersonalDataPage()
        {
            User user=new User(CurrentUser.CurrentClient.Username, CurrentUser.CurrentClient.Password,CurrentUser.CurrentClient.Name,
                               CurrentUser.CurrentClient.Surname, CurrentUser.CurrentClient.Email, CurrentUser.CurrentClient.PhoneNumber);
            user.UserCategory = "Client";
            user.Id= CurrentUser.CurrentClient.Id.ToString();
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"User",user }
            };

            await Shell.Current.GoToAsync(nameof(EditPersonalDataPage),parameters);
        }

        public string PrintGreeting()
        {
            return $"Welcome to your account, {CurrentUser.CurrentClient.Name}!";
        }

        [RelayCommand]
        public async Task MakeRequest() => await GoToCreateRequestPage();

        private async Task GoToCreateRequestPage()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"ClientId",CurrentUser.CurrentClient.Id }
            };

            await Shell.Current.GoToAsync(nameof(CreateRequestPage),parameters);
        }

        [RelayCommand]
        public async Task CheckOpenRequests() => await GoToRequestsPage();
        private async Task GoToRequestsPage()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"ClientId",CurrentUser.CurrentClient.Id }
            };

            await Shell.Current.GoToAsync(nameof(RequestsListPage), parameters);
        }


        [RelayCommand]
        public async Task CheckNotApprovedRequests() => await GoToNotApprovedRequestsPage();
        private async Task GoToNotApprovedRequestsPage()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"ClientId",CurrentUser.CurrentClient.Id }
            };

            await Shell.Current.GoToAsync(nameof(NotApprovedRequestsPage), parameters);
        }

        [RelayCommand]
        public async Task CheckNotReadyOrders() => await GoToNotReadyOrders();
        private async Task GoToNotReadyOrders()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"ClientId",CurrentUser.CurrentClient.Id }
            };

            await Shell.Current.GoToAsync(nameof(OrdersInProcessPage), parameters);
        }


        [RelayCommand]
        public async Task LogOut() => await PerformLogOutOperation();
        private async Task PerformLogOutOperation()
        {
            CurrentUser.CurrentClient = null;
            await Shell.Current.GoToAsync(nameof(LogInPage));
        }

        [RelayCommand]
        public async Task GetNotifications() => await GoToNotificationsPage();
        private async Task GoToNotificationsPage()
        {
            await Shell.Current.GoToAsync(nameof(NotificationsPage));
        }

        [RelayCommand]
        public async Task CheckReadyOrders() => await GoToReadyOrders();
        private async Task GoToReadyOrders()
        {
            await Shell.Current.GoToAsync(nameof(ClientReadyOrdersPage));
        }

        [RelayCommand]
        public async Task AddNewCard()
        {
            await Shell.Current.GoToAsync(nameof(AddNewCardPage));
        }

        [RelayCommand]
        public async Task CheckAllCards()
        {
            await Shell.Current.GoToAsync(nameof(CardsPage));
        }

        [RelayCommand]
        public async Task CheckOrdersToTake()
        {
            await Shell.Current.GoToAsync(nameof(OrdersToTakeBackPage));
        }
    }
}
