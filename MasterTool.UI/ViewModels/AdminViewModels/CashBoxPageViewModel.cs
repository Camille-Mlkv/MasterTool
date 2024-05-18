using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MasterToolDomain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.AdminViewModels
{
    public partial class CashBoxPageViewModel:ObservableObject
    {
        [ObservableProperty]
        private bool _onlyIncome;

        [ObservableProperty]
        private bool _onlyExpense;

        [ObservableProperty]
        public ObservableCollection<CashBoxNote> _notes;

        private DatabaseContext _context;
        public CashBoxPageViewModel(DatabaseContext context)
        {
            _context = context;
            Notes = new ObservableCollection<CashBoxNote>();
            OnlyIncome = false;
            OnlyExpense = false;
        }

        [RelayCommand]
        public async Task LoadCashNotes() => await GetCashNotes();
        private async Task GetCashNotes()
        {
            var notes = await _context.GetAllAsync<CashBoxNote>();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Notes.Clear();
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
            );
        }

        [RelayCommand]
        public async Task GoBack() => await GoToHomePage();
        private async Task GoToHomePage()
        {
            await Shell.Current.GoToAsync(nameof(AdminHomePage));
        }

        [RelayCommand]
        private async Task FilterNotes()
        {
            if (Notes == null) return;

            var filtered = await _context.GetAllAsync<CashBoxNote>();

            if (OnlyIncome)
            {
                filtered = new ObservableCollection<CashBoxNote>(filtered.Where(n => n.IsIncome==true));
            }
            else if (OnlyExpense)
            {
                filtered = new ObservableCollection<CashBoxNote>(filtered.Where(n => n.IsIncome ==false));
            }

            Notes.Clear();
            foreach(var note in filtered)
            {
                Notes.Add(note);
            }
            
        }
    }
}
