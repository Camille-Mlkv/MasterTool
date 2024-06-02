using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.AdminViewModels
{
    [QueryProperty("Request",nameof(Request))]
    public partial class RejectRequestPageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        [ObservableProperty]
        private Request _request;

        [ObservableProperty]
        private string _comment;

        [ObservableProperty]
        private bool _isWithoutComment;
        public RejectRequestPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task Reject()
        {
            Request.IsRejected = true;
            if(Comment != null)
            {
                Request.Comment = Comment;
            }
            await _context.UpdateItemAsync<Request>(Request);
            await Shell.Current.DisplayAlert("Notification", "Отказано", "OK");
            await Shell.Current.GoToAsync(nameof(RequestsToConfirmPage));
        }
    }
}
