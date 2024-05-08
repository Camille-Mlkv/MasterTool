using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterTool.UI.Pages.ClientPages;
using MasterToolDomain.Entities;
using MAUISql.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MasterTool.UI.ViewModels
{
    public partial class SignUpPageViewModel:ObservableObject
    {
        private DatabaseContext _context;
        private List<string> _usernamesList;

        [ObservableProperty]
        User userModel;

        [ObservableProperty]
        string userType="Client";

        [ObservableProperty]
        string identificationKey="";

        public SignUpPageViewModel(DatabaseContext context)
        {
            _context = context;
            UserModel=new User();
            _usernamesList=new List<string>();
        }

        [RelayCommand]
        public async Task SignUp() => await PerformSignUpOperation();


        private async Task PerformSignUpOperation()
        {
            User newUser = new User(UserModel.Username, UserModel.Password, UserModel.Name, UserModel.Surname, UserModel.Email, UserModel.PhoneNumber);

            if (UserType == "Client")
            {
                Client client = new Client(newUser);
                await _context.AddItemAsync<Client>(client);
                CurrentUser.CurrentClient = client;
                //IDictionary<string, object> parameters = new Dictionary<string, object>()
                //{
                //    { "Client", client }
                //};

                await Shell.Current.GoToAsync(nameof(ClientHomePage)); //parameters
            }
            else
            {
                UserKey key = new UserKey(UserType, IdentificationKey);
                var found = await _context.FindAsync<UserKey>(key);
                //var found = await _context.GetFileteredAsync<UserKey>(k=>k.UserType == UserType && k.Key==IdentificationKey);
                if (found != null)
                {
                    await _context.DeleteItemByKeyAsync<UserKey>(found.Id);

                    if (UserType == "Master")
                    {
                        Master master = new Master(newUser);
                        await _context.AddItemAsync<Master>(master);
                        //go to master page
                    }

                    if (UserType == "Admin")
                    {
                        Admin admin = new Admin(newUser);
                        await _context.AddItemAsync<Admin>(admin);
                        //go to admin page
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Alert", "Key is incorrect", "Ok");
                }
                
            }
        }

        public async Task LoadAllUsernames()
        {
            var data1=await _context.GetAllAsync<Client>();
            foreach (var item in data1)
            {
                _usernamesList.Add(item.Username);
            }
            var data2= await _context.GetAllAsync<Master>();
            foreach (var item in data2)
            {
                _usernamesList.Add(item.Username);
            }
            var data3 = await _context.GetAllAsync<Admin>();
            foreach (var item in data3)
            {
                _usernamesList.Add(item.Username);
            }

        }

        public bool UsernameIsUnique(string text)
        {
            if (!_usernamesList.Contains(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
