using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterToolDomain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels
{
    [QueryProperty(nameof(OrderId), nameof(OrderId))]
    public partial class DetailsPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private int _orderId;

        private DatabaseContext _context;
        public ObservableCollection<Detail> Details { get; set; } = new();

        [ObservableProperty]
        private bool isAdmin=false;

        [ObservableProperty]
        private bool isMaster=false;
        public DetailsPageViewModel(DatabaseContext context)
        {
            _context = context;
            CheckUser();
        }

        [RelayCommand]
        public async Task LoadDetails()
        {
            var details=await _context.GetAllAsync<Detail>();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Details.Clear();
                foreach (var detail in details)
                    Details.Add(detail);
            });
        }

        private void CheckUser()
        {
            if (CurrentUser.CurrentAdmin != null)
            {
                // Логика для определения, является ли текущий пользователь администратором или мастером
                if (CurrentUser.CurrentAdmin.Id != 0)
                {
                    IsAdmin = true;
                    IsMaster = false;
                }
                else
                {
                    IsAdmin = false;
                    IsMaster = true;
                }
            }
            
            else IsMaster = true;
        }

        [RelayCommand]
        public async Task AddDetail()
        {
            await Shell.Current.GoToAsync(nameof(AddNewDetailPage));
        }

        [RelayCommand]
        public async Task NavigateToDetailPage(Detail detail)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"Detail",detail }
            };

            if (IsAdmin)
            {
                await Shell.Current.GoToAsync(nameof(DetailInformationPage), parameters);
            }
            else if (IsMaster)
            {
                parameters.Add("OrderId", OrderId);
                await Shell.Current.GoToAsync(nameof(DetailInformationPage), parameters);
            }
        }

        [RelayCommand]
        public async Task GoBack()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"OrderId",OrderId }
            };

            await Shell.Current.GoToAsync(nameof(StoragePage), parameters);
        }
    }
}
