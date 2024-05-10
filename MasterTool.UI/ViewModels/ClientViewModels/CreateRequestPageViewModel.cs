using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterTool.UI.Pages.ClientPages;
using MAUISql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    [QueryProperty(nameof(ClientId),"ClientId")]
    public partial class CreateRequestPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private Request _request;

        [ObservableProperty]
        private int _clientId;

        private DatabaseContext _context;

        public CreateRequestPageViewModel(DatabaseContext context)
        {
            _context = context;
            Request=new Request();
        }

        [RelayCommand]
        public async Task CreateRequest() => await SaveNewRequest();

        private async Task SaveNewRequest()
        {
            Request.ClientId = ClientId;
            Request.IsApproved = false;
            Request.IsOrder = false;
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
