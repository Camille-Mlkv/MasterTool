using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    [QueryProperty(nameof(Order),nameof(Order))]
    public partial class PayByCardPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private Order _order;

        [ObservableProperty]
        private bool _isLoading=false;
        public ObservableCollection<BankCard> ClientCards { get; set; } = new();

        private DatabaseContext _context;
        public PayByCardPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task LoadCards()
        {
            var cards = await _context.GetFileteredAsync<BankCard>(c => c.ClientId == CurrentUser.CurrentClient.Id);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                ClientCards.Clear();
                foreach (var card in cards)
                {
                    ClientCards.Add(card);
                }
            });
        }

        [RelayCommand]
        public async Task PayOrder()
        {
            IsLoading = true;
            await Task.Delay(2000); // Имитируем загрузку
            IsLoading = false;
            await Application.Current.MainPage.DisplayAlert("Оплата", "Оплата прошла успешно!", "OK");

            var date = DateTime.Now.ToString();
            CashBoxNote note = new CashBoxNote(true, $"Оплата заказа {Order.Id} ", date, Order.Price);
            await _context.AddItemAsync<CashBoxNote>(note);

            Order.IsPaid = true;
            await _context.UpdateItemAsync<Order>(Order);

            await Shell.Current.GoToAsync(nameof(ClientReadyOrdersPage));
        }
    }
}
