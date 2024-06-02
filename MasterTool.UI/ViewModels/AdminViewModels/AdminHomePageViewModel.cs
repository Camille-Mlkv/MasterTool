using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MasterTool.UI.ViewModels
{
    public partial class AdminHomePageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        public AdminHomePageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task GetPersonalData() => await GoToPersonalDataPage();

        private async Task GoToPersonalDataPage()
        {
            User user = new User(CurrentUser.CurrentAdmin.Username, CurrentUser.CurrentAdmin.Password, CurrentUser.CurrentAdmin.Name,
                               CurrentUser.CurrentAdmin.Surname, CurrentUser.CurrentAdmin.Email, CurrentUser.CurrentAdmin.PhoneNumber);
            user.UserCategory = "Admin";
            user.Id = CurrentUser.CurrentAdmin.Id.ToString();
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"User",user }
            };

            await Shell.Current.GoToAsync(nameof(EditPersonalDataPage), parameters);
        }

        public string PrintGreeting()
        {
            return $"Welcome to your account, {CurrentUser.CurrentAdmin.Name}!";
        }

        [RelayCommand]
        public async Task LogOut() => await PerformLogOutOperation();
        private async Task PerformLogOutOperation()
        {
            CurrentUser.CurrentAdmin = null;
            await Shell.Current.GoToAsync(nameof(LogInPage));
        }


        [RelayCommand]
        public async Task CheckOpenRequests() => await GoToOpenRequestsPage();
        private async Task GoToOpenRequestsPage()
        {
            await Shell.Current.GoToAsync(nameof(RequestsToConfirmPage));
        }

        [RelayCommand]
        public async Task AddNewService() => await GoToAddNewServicePage();
        private async Task GoToAddNewServicePage()
        {
            await Shell.Current.GoToAsync(nameof(AddNewServicePage));
        }

        [RelayCommand]
        public async Task CheckServices() => await GoToServicesPage();
        private async Task GoToServicesPage()
        {
            await Shell.Current.GoToAsync(nameof(CheckServicesPage));
        }

        [RelayCommand]
        public async Task CheckCashBox() => await GoToCashBoxPage();
        private async Task GoToCashBoxPage()
        {
            await Shell.Current.GoToAsync(nameof(CashBoxPage));
        }

        [RelayCommand]
        public async Task CheckStorage() => await GoToStoragePage();
        private async Task GoToStoragePage()
        {
            await Shell.Current.GoToAsync(nameof(StoragePage));
        }

        [RelayCommand]
        public async Task CheckFeedbacks()
        {
            await Shell.Current.GoToAsync(nameof(FeedbacksPage));
        }

        [RelayCommand]
        public async Task CheckOrdersToTake()
        {
            await Shell.Current.GoToAsync(nameof(OrdersToTakeBackPage));
        }
    }
}
