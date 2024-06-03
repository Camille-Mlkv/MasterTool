using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterToolDomain.Entities;
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
            IEnumerable<Notification> notifications;
            if (CurrentUser.CurrentClient != null)
            {
                if (CurrentUser.CurrentClient.Id != 0)
                {
                    notifications = await _context.GetFileteredAsync<Notification>(n => n.ReceiverId == CurrentUser.CurrentClient.Id && n.IsForClient==true);
                }
                else
                {
                    notifications = await _context.GetFileteredAsync<Notification>(n => n.ReceiverId == CurrentUser.CurrentMaster.Id && n.IsForClient == false);
                }
            }
            else
            {
                notifications = await _context.GetFileteredAsync<Notification>(n => n.ReceiverId == CurrentUser.CurrentMaster.Id && n.IsForClient == false);
            }
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Notifications.Clear();
                foreach (var n in notifications)
                    Notifications.Add(n);
            });
        }
    }
}
