using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.AdminViewModels
{
    [QueryProperty(nameof(OrderId), nameof(OrderId))]
    public partial class StoragePageViewModel:ObservableObject
    {
        [ObservableProperty]
        private int _orderId;

        [RelayCommand]
        public async Task ViewDetails()
        {
            if(OrderId == 0)
            {
                await Shell.Current.GoToAsync(nameof(DetailsPage));
            }
            else
            {
                IDictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"OrderId",OrderId }
                };
                await Shell.Current.GoToAsync(nameof(DetailsPage), parameters);
            }
            
        }

        [RelayCommand]
        public async Task ViewMaterials()
        {
            await Shell.Current.GoToAsync(nameof(AdminHomePage));
        }


        [RelayCommand]
        public async Task GoBack()
        {
            if (OrderId != 0)
            {
                await Shell.Current.GoToAsync(nameof(MasterHomePage));
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(AdminHomePage));
            }
            
        }
    }
}
