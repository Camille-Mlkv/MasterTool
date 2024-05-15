using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterTool.UI.Pages.MasterPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.MasterViewModels
{
    public partial class MasterReadyOrdersPageViewModel:ObservableObject
    {
        private DatabaseContext _context;
        public ObservableCollection<Order> Orders { get; set; } = new();
        public MasterReadyOrdersPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task LoadReadyOrders() => await GetReadyOrders();
        private async Task GetReadyOrders()
        {
            var orders = await _context.GetFileteredAsync<Order>(o => o.MasterId == CurrentUser.CurrentMaster.Id && o.IsReady == true);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Orders.Clear();
                foreach (var order in orders)
                    Orders.Add(order);
            });
        }

        [RelayCommand]
        public async Task GoBack() => await GoToHomePage();
        private async Task GoToHomePage()
        {
            await Shell.Current.GoToAsync(nameof(MasterHomePage));
        }
    }
}
