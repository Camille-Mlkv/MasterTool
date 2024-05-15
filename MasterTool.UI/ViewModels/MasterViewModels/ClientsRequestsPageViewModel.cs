﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterTool.UI.Pages.MasterPages;
using MasterToolDomain.Entities;
using MAUISql.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.MasterViewModels
{
    [QueryProperty(nameof(Service),"Service")]
    public partial class ClientsRequestsPageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        [ObservableProperty]
        private Service _service;

        public ObservableCollection<Request> Requests { get; set; } = new();
        public ClientsRequestsPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task LoadRequests() => await GetRequestsByService();
        private async Task GetRequestsByService()
        {
            var requests = await _context.GetFileteredAsync<Request>(r => r.IsOrder == false && r.IsApproved == true && r.Service == Service.ServiceName);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Requests.Clear();
                foreach (var r in requests)
                    Requests.Add(r);
            });
        }

        [RelayCommand]
        public async Task AcceptRequest(Request request) => await CreateNewOrder(request);
        private async Task CreateNewOrder(Request request)
        {
            request.IsOrder = true;
            await _context.UpdateItemAsync<Request>(request);
            string date = DateTime.Today.ToString();
            Order newOrder = new Order(date, request.Id, CurrentUser.CurrentMaster.Id, request.ClientId, false, Service.Tarif);
            await _context.AddItemAsync<Order>(newOrder);
            await Shell.Current.DisplayAlert("Notify", "OK", "OK");

            var notification=new Notification($"Master {CurrentUser.CurrentMaster.Name} accepted your request #{request.Id}!",date,request.Id,request.ClientId);
            await _context.AddItemAsync<Notification>(notification);

            await Shell.Current.GoToAsync(nameof(MasterHomePage));
        }
    }
}