using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterToolDomain.Entities;
using MAUISql.Data;
using System.Collections.ObjectModel;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    public partial class NotificationsPageViewModel:ObservableObject
    {

        private DatabaseContext _context;
        public ObservableCollection<Notification> Notifications { get; set; } = new();
        public NotificationsPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task LoadNotifications() => await GetClientNotifications();
        private async Task GetClientNotifications()
        {
            var notifications = await _context.GetFileteredAsync<Notification>(n=>n.ClientId==CurrentUser.CurrentClient.Id);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Notifications.Clear();
                foreach (var n in notifications)
                    Notifications.Add(n);
            });
        }
    }
}
