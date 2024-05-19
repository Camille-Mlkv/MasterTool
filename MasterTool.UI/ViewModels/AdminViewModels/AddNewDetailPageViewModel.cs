using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterToolDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.AdminViewModels
{
    public partial class AddNewDetailPageViewModel:ObservableObject
    {
        private DatabaseContext _context;
        [ObservableProperty]
        private Detail _detail;
        public AddNewDetailPageViewModel(DatabaseContext context)
        {
            _context = context;
            Detail = new Detail();
        }

        [RelayCommand]
        public async Task CreateDetail() => await SaveNewDetail();

        private async Task SaveNewDetail()
        {
            await _context.AddItemAsync<Detail>(Detail);
            await Shell.Current.DisplayAlert("Notification", "Деталь успешно добавлена", "OK");

            double sum = Detail.Price * Detail.Amount;
            var date = DateTime.Now.ToString();
            var cashNote=new CashBoxNote(false,$"Закупка деталей {Detail.Name}",date,sum);
            await _context.AddItemAsync<CashBoxNote>(cashNote);

            await Shell.Current.GoToAsync(nameof(AdminHomePage));
        }

        [RelayCommand]
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync(nameof(DetailsPage));
        }
    }
}
