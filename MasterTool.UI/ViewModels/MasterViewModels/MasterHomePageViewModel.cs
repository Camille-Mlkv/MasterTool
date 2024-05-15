using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MasterTool.UI.ViewModels.MasterViewModels
{
    public partial class MasterHomePageViewModel:ObservableObject
    {
        private DatabaseContext _context;
        public MasterHomePageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        public string PrintGreeting()
        {
            return $"Welcome to your account, {CurrentUser.CurrentMaster.Name}!";
        }

        [RelayCommand]
        public async Task GetPersonalData() => await GoToPersonalDataPage();

        private async Task GoToPersonalDataPage()
        {
            User user = new User(CurrentUser.CurrentMaster.Username, CurrentUser.CurrentMaster.Password, CurrentUser.CurrentMaster.Name,
                               CurrentUser.CurrentMaster.Surname, CurrentUser.CurrentMaster.Email, CurrentUser.CurrentMaster.PhoneNumber);
            user.UserCategory = "Master";
            user.Id = CurrentUser.CurrentMaster.Id.ToString();
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"User",user }
            };

            await Shell.Current.GoToAsync(nameof(EditPersonalDataPage), parameters);
        }

        [RelayCommand]
        public async Task CheckClientsRequests() => await GoToClientsRequestPage();
        private async Task GoToClientsRequestPage()
        {
            await Shell.Current.GoToAsync(nameof(ServicesPage));
        }

        [RelayCommand]
        public async Task LogOut() => await PerformLogOutOperation();
        private async Task PerformLogOutOperation()
        {
            CurrentUser.CurrentMaster = null;
            await Shell.Current.GoToAsync(nameof(LogInPage));
        }

        [RelayCommand]
        public async Task LoadOrdersInProcess() => await GoToNotReadyOrdersPage();
        private async Task GoToNotReadyOrdersPage()
        {
            await Shell.Current.GoToAsync(nameof(OrdersInProcessMasterPage));
        }

        [RelayCommand]
        public async Task LoadReadyOrders() => await GoToReadyOrders();
        private async Task GoToReadyOrders()
        {
            await Shell.Current.GoToAsync(nameof(MasterReadyOrdersPage));
        }
    }
}
