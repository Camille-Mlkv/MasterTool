using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUISql.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    [QueryProperty(nameof(ClientId), "ClientId")]
    public partial class RequestsListPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private int _clientId;

        private DatabaseContext _context;

        public ObservableCollection<Request> Requests { get; set; } = new();

        public RequestsListPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task UpdateRequestsList() => await GetClientRequests();
        private async Task GetClientRequests()
        {
            var requests = await _context.GetFileteredAsync<Request>(r => r.ClientId == ClientId && r.IsApproved==true &&r.IsOrder==false);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Requests.Clear();
                foreach (var request in requests)
                    Requests.Add(request);
            });

        }


    }
}
