﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterTool.UI.Pages;
using MasterTool.UI.Pages.AdminPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}