using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    [QueryProperty(nameof(ClientId),"ClientId")]
    public partial class CreateRequestPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private Request _request;

        [ObservableProperty]
        private int _clientId;

        public ObservableCollection<string> Services { get; set; } = new();

        private DatabaseContext _context;

        public CreateRequestPageViewModel(DatabaseContext context)
        {
            _context = context;
            Request=new Request();
        }


        [RelayCommand]
        public async Task LoadServices()
        {
            var services = await _context.GetAllAsync<Service>();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Services.Clear();
                foreach (var s in services)
                    Services.Add(s.ServiceName);
            });
        }


        [RelayCommand]
        public async Task CreateRequest() => await SaveNewRequest();

        private async Task SaveNewRequest()
        {
            Request.ClientId = ClientId;
            Request.IsApproved = false;
            Request.IsOrder = false;
            Request.IsRejected = false;
            await _context.AddItemAsync<Request>(Request);
            await Shell.Current.DisplayAlert("Notification", "Запрос успешно отправлен на подтверждение.", "OK");

            //IDictionary<string, object> parameters = new Dictionary<string, object>
            //{
            //    {"Client",Client }
            //};
            await Shell.Current.GoToAsync(nameof(ClientHomePage));//parameters
        }
    }
}
