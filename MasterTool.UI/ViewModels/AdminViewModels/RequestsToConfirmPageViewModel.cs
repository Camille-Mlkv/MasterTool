using CommunityToolkit.Mvvm.ComponentModel;
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
            var requests = await _context.GetFileteredAsync<Request>(r => r.IsApproved == false && r.IsOrder == false);
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
            var note = new Notification($"Ваша заявка {request.Id} успешно одобрена",DateTime.Today.ToString(),request.Id,request.ClientId) ;
            await _context.AddItemAsync<Notification>(note);
            await Shell.Current.DisplayAlert("Notification", "Заявка успешно одобрена", "OK");
            await UpdateRequestsList();
        }

        //disapprove
    }
}
