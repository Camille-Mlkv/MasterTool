using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MasterTool.UI.ViewModels
{
    [QueryProperty(nameof(OrderId), nameof(OrderId))]
    [QueryProperty(nameof(Detail), nameof(Detail))]
    public partial class DetailInformationPageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        [ObservableProperty]
        private int _orderId;

        [ObservableProperty]
        private bool isAdmin = false;

        [ObservableProperty]
        private bool isMaster = false;

        [ObservableProperty]
        private Detail detail;

        public DetailInformationPageViewModel(DatabaseContext context)
        {
            _context = context;
            CheckUser();
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
        public async Task GoBack()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"OrderId",OrderId }
            };

            await Shell.Current.GoToAsync(nameof(DetailsPage),parameters);
        }

        [RelayCommand]
        public async Task AddDetail()
        {
            bool isValidInput = false;
            int quantity = 0;

            while (!isValidInput)
            {
                string result = await Shell.Current.DisplayPromptAsync("Введите количество", "Количество деталей:", maxLength: 2);
                if (result == null)
                {
                    return;
                }
                if (int.TryParse(result, out quantity) && quantity > 0 && quantity<=Detail.Amount)
                {
                    isValidInput = true;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Пожалуйста, введите положительное число.", "OK");
                }
            }

            //1. Добавить в БД данные об использовании деталей (если такая деталь уже была использована, обновить имеющуюся запись)
            bool alreadyUsed = (await _context.GetFileteredAsync<OrderDetail>(d => d.DetailId == Detail.Id)).Any();
            if (alreadyUsed)
            {
                var existingDetail= (await _context.GetFileteredAsync<OrderDetail>(d => d.DetailId == Detail.Id)).FirstOrDefault();
                existingDetail.Amount += quantity;
                await _context.UpdateItemAsync<OrderDetail>(existingDetail);
            }
            else
            {
                var orderDetail = new OrderDetail(OrderId, Detail.Id, quantity);
                await _context.AddItemAsync<OrderDetail>(orderDetail);
            }
            

            //2. Изменить количество деталей
            Detail.Amount -= quantity;
            await _context.UpdateItemAsync<Detail>(Detail);

            //3. Добавить расход в кассу 
            string date = DateTime.Now.ToString();
            CashBoxNote note = new CashBoxNote(false, $"Использование деталей типа {Detail.Name}", date, quantity * Detail.Price);
            await _context.AddItemAsync<CashBoxNote>(note);

            //4. Обновить стоимость заказа
            var order = await _context.GetItemByKeyAsync<Order>(OrderId);
            order.Price += quantity * Detail.Price;
            await _context.UpdateItemAsync<Order>(order);

            //5. Вернуться на страницу заказа.
            await Shell.Current.DisplayAlert("Notification", "Деталь добавлена к заказу", "OK");
            IDictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"Order",order }
            };

            await Shell.Current.GoToAsync(nameof(OrderDetailsMasterPage), parameters);
        }


        [RelayCommand]
        public async Task EditDetailAmount()
        {
            bool isValidInput = false;
            int quantity = 0;

            while (!isValidInput)
            {
                string result = await Shell.Current.DisplayPromptAsync("Введите количество", "Количество деталей:", maxLength: 2);
                if (result == null)
                {
                    return;
                }

                if (int.TryParse(result, out quantity) && quantity > 0 && quantity > Detail.Amount)
                {
                    isValidInput = true;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Пожалуйста, введите положительное число.", "OK");
                }
            }

            var existingDetail = (await _context.GetFileteredAsync<Detail>(d => d.Id == Detail.Id)).FirstOrDefault();
            var dif = quantity - existingDetail.Amount;
            existingDetail.Amount = quantity;
            await _context.UpdateItemAsync<Detail>(existingDetail);

            string date = DateTime.Now.ToString();
            CashBoxNote note = new CashBoxNote(false, $"Добавление деталей типа {Detail.Name}", date, dif * Detail.Price);
            await _context.AddItemAsync<CashBoxNote>(note);

        }
    }
}
