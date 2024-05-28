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
    public partial class CardsPageViewModel:ObservableObject
    {
        private DatabaseContext _context;
        public ObservableCollection<BankCard> ClientCards { get; set; } = new();
        public CardsPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task LoadClientCards()
        {
            var cards=await _context.GetAllAsync<BankCard>();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                ClientCards.Clear();
                foreach (var card in cards)
                {
                    ClientCards.Add(card);
                }
            });
        }
    }
}
