using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterToolDomain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.ClientViewModels
{
    public partial class OrdersToTakeBackPageViewModel : ObservableObject
    {
        private DatabaseContext _context;
        public ObservableCollection<Order> Orders { get; set; } = new();

        [ObservableProperty]
        private bool isAdmin=false;

        [ObservableProperty]
        private string searchQuery;
        public OrdersToTakeBackPageViewModel(DatabaseContext context)
        {
            _context = context;
            CheckUser();
        }

        private void CheckUser()
        {
            if (CurrentUser.CurrentAdmin != null)
            {
                if (CurrentUser.CurrentAdmin.Id != 0)
                {
                    IsAdmin = true;
                }
                else
                {
                    IsAdmin = false;
                }
            }
        }

        [RelayCommand]
        public async Task LoadOrders()
        {
            IEnumerable<Order> orders = null;
            if (!IsAdmin) //change check
            {
                orders = await _context.GetFileteredAsync<Order>(o => o.ClientId == CurrentUser.CurrentClient.Id && o.IsPaid == true && o.IsTaken == false && o.IsReady==true);
            }
            else
            {
                orders = await _context.GetFileteredAsync<Order>(o => o.IsPaid == true && o.IsTaken == false && o.IsReady==true);
            }
            
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Orders.Clear();
                foreach(var order in orders)
                {
                    Orders.Add(order);
                }
            });
        }

        [RelayCommand]
        public async Task GoBack()
        {
            if(IsAdmin)
            {
                await Shell.Current.GoToAsync(nameof(AdminHomePage));
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(ClientHomePage));
            }
        }

        [RelayCommand]
        public async Task ShowDetails(Order order)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Order", order }
            };

            await Shell.Current.GoToAsync(nameof(OrderDetailsPage), parameters);
        }

        [RelayCommand]
        public async Task GiveOrder(Order order)
        {
            order.IsTaken = true;
            await _context.UpdateItemAsync<Order>(order);

            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd HH:mm");
            var notification = new Notification($"Клиент принял заказ {order.Id}", date, order.Id, order.MasterId,false);
            await _context.AddItemAsync<Notification>(notification);

            await Shell.Current.DisplayAlert("Notification", "Успешно!", "OK");
        }


        [RelayCommand]
        public async Task RefuseOrder(Order order)
        {
            order.IsReady = false;
            order.Price = 0;
            await _context.UpdateItemAsync<Order>(order);

            string refusingReason = await Shell.Current.DisplayPromptAsync("Введите причину отказа", "Проблема:", maxLength: 100);

            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd HH:mm");
            var notification = new Notification($"Клиент отказался от заказа {order.Id},причина: "+ refusingReason, date, order.Id, order.MasterId,false);
            await _context.AddItemAsync<Notification>(notification);

            await Shell.Current.DisplayAlert("Notification", "Заказ отмечен как невыполненный.", "OK");
        }

        //поиск
        [RelayCommand]
        public async Task SearchOrdersByClientData(string text)
        {
            var client = (await _context.GetFileteredAsync<Client>(c => c.PhoneNumber == SearchQuery)).FirstOrDefault();
            if(client == null)
            {
                await Shell.Current.DisplayAlert("Alert", "Такого номера нет", "OK");
            }
            else
            {
                int clientId = client.Id;
                var orders = Orders.Where(o => o.ClientId == clientId).ToList();
                Orders.Clear();
                foreach(var o in orders)
                {
                    Orders.Add(o);
                }
            }
        }
    }

}
