using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterTool.UI.Pages.AdminPages;
using MasterTool.UI.Pages.ClientPages;
using MasterTool.UI.Pages.MasterPages;
using MAUISql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels
{
    [QueryProperty("User","User")]
    public partial class EditPersonalDataPageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        [ObservableProperty]
        private User _user;

        public EditPersonalDataPageViewModel(DatabaseContext context)
        {
            _context = context;
            User = new User();
        }

        [RelayCommand]
        public async Task SaveAndLeave() => await SaveData();

        private async Task SaveData()
        {
            if (User.UserCategory == "Client")
            {
                Client client = new Client(User);
                client.Id = Convert.ToInt32(User.Id);
                CurrentUser.CurrentClient = client; //update in program

                await _context.UpdateItemAsync<Client>(client);

                await Shell.Current.DisplayAlert("Alert", "Updated", "Ok");
                await Shell.Current.GoToAsync(nameof(ClientHomePage));
            }
            else if(User.UserCategory == "Master")
            {
                Master master = new Master(User);
                master.Id = Convert.ToInt32(User.Id);
                CurrentUser.CurrentMaster = master;

                await _context.UpdateItemAsync<Master>(master);

                await Shell.Current.DisplayAlert("Alert", "Updated", "Ok");

                await Shell.Current.GoToAsync(nameof(MasterHomePage));

            }
            else if (User.UserCategory == "Admin")
            {
                Admin admin = new Admin(User);
                admin.Id = Convert.ToInt32(User.Id);
                CurrentUser.CurrentAdmin = admin;

                await _context.UpdateItemAsync<Admin>(admin);

                await Shell.Current.DisplayAlert("Alert", "Updated", "Ok");

                await Shell.Current.GoToAsync(nameof(AdminHomePage));
            }
        }


    }
}
