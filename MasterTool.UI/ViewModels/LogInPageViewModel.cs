using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MasterTool.UI.ViewModels
{
    public partial class LogInPageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        [ObservableProperty]
        User _enteredUser;

        public LogInPageViewModel(DatabaseContext context)
        {
            _context = context;
            _enteredUser = new User();
        }

        [RelayCommand]
        public async Task LogIn() => await PerformLogInOperation();

        private async Task PerformLogInOperation()
        {
            IEnumerable<Client> clientSearch = await _context.GetFileteredAsync<Client>(t => t.Username == EnteredUser.Username && t.Password==EnteredUser.Password);
            if (clientSearch.Any())
            {
                Client client=clientSearch.First();
                CurrentUser.CurrentClient = client;
                await Shell.Current.GoToAsync(nameof(ClientHomePage)); //go to client page parameters

                return;
            }
            else
            {
                IEnumerable<Master> masterSearch = await _context.GetFileteredAsync<Master>(t => t.Username == EnteredUser.Username && t.Password == EnteredUser.Password);
                if (masterSearch.Any())
                {
                    Master master=masterSearch.First();
                    CurrentUser.CurrentMaster = master;
                    await Shell.Current.GoToAsync(nameof(MasterHomePage));                    //go to master page
                    return;
                }
                else
                {
                    IEnumerable<Admin> adminSearch = await _context.GetFileteredAsync<Admin>(t => t.Username == EnteredUser.Username && t.Password == EnteredUser.Password);
                    if (adminSearch.Any())
                    {
                        Admin admin=adminSearch.First();
                        CurrentUser.CurrentAdmin = admin;
                        await Shell.Current.GoToAsync(nameof(AdminHomePage));
                        return;
                    }
                }
            }
            await Shell.Current.DisplayAlert("Alert", "Invalid data,try again", "OK");
        }
    }
}
