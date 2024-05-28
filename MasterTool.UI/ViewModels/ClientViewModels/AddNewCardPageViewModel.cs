using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    public partial class AddNewCardPageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        [ObservableProperty]
        private string _cardNumber;

        [ObservableProperty]
        private DateTime _expirationDate;

        [ObservableProperty]
        private string _cvc;

        public DateTime MinimumExpirationDate { get; }
        public AddNewCardPageViewModel(DatabaseContext context)
        {
            _context = context;
            var today = DateTime.Today;
            MinimumExpirationDate = new DateTime(today.Year, today.Month, 1).AddMonths(1);
        }

        [RelayCommand]
        public async Task SaveCard()
        {
            var newCardNumber=CardNumber.Replace(" ", "");
            var card = new BankCard(CurrentUser.CurrentClient.Id, newCardNumber, Cvc, ExpirationDate.ToString("dd/MM/yyyy"));
            var existing_cards = await _context.GetFileteredAsync<BankCard>(c => c.CardNumber == CardNumber && c.ClientId==CurrentUser.CurrentClient.Id);
            if (existing_cards.Any())
            {
                await Shell.Current.DisplayAlert("Alert", "Карта с таким номером уже была добавлена", "OK");
            }
            else
            {
                await _context.AddItemAsync<BankCard>(card);
                await Shell.Current.DisplayAlert("Alert", "Карта успешно добавлена!", "OK");
                await Shell.Current.GoToAsync(nameof(CardsPage));
            }
        }
    }
}
