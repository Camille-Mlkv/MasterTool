﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MasterTool.UI.ViewModels.AdminViewModels
{
    public partial class RequestsToConfirmPageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        public ObservableCollection<Request> Requests { get; set; } = new();

        public RequestsToConfirmPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task UpdateRequestsList() => await GetNotApprovedRequests();
        private async Task GetNotApprovedRequests()
        {
            var requests = await _context.GetFileteredAsync<Request>(r => r.IsApproved == false && r.IsOrder == false &&r.IsRejected==false);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Requests.Clear();
                foreach (var request in requests)
                    Requests.Add(request);
            });

        }

        [RelayCommand]
        public async Task ApproveRequest(Request request) => await PerformApproving(request);
        private async Task PerformApproving(Request request)
        {
            request.IsApproved = true;
            await _context.UpdateItemAsync<Request>(request);

            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd HH:mm");
            var note = new Notification($"Ваша заявка {request.Id} успешно одобрена",date,request.Id,request.ClientId,true) ;
            await _context.AddItemAsync<Notification>(note);

            await Shell.Current.DisplayAlert("Notification", "Заявка успешно одобрена", "OK");
            await UpdateRequestsList();
        }

        [RelayCommand]
        public async Task RejectRequest(Request request)
        {
            IDictionary<string,object> parameters= new Dictionary<string, object>
            {
                {"Request",request }
            };
            await Shell.Current.GoToAsync(nameof(RejectRequestPage),parameters);
        }

        [RelayCommand]
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync(nameof(AdminHomePage));
        }
    }
}
