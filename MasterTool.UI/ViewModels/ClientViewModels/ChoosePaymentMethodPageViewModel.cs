using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterToolDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    [QueryProperty(nameof(Order),"Order")]
    public partial class ChoosePaymentMethodPageViewModel:ObservableObject
    {

        [ObservableProperty]
        private Order _order;

        [ObservableProperty]
        private Request _request;

        private DatabaseContext _context;
        public ChoosePaymentMethodPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task LoadOrderDetails()
        {
            Request = await _context.GetItemByKeyAsync<Request>(Order.BaseRequestId);
        }

        [RelayCommand]
        public async Task Proceed()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"Order",Order }
            };

            await Shell.Current.GoToAsync(nameof(PayByCardPage), parameters);
            return;

        }
    }
}
