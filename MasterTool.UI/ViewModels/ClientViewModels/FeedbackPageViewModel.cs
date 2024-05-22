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
    [QueryProperty(nameof(OrderId), nameof(OrderId))]
    public partial class FeedbackPageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        [ObservableProperty]
        private string _feedbackText;

        [ObservableProperty]
        private int _orderId;

        [ObservableProperty]
        private int _rate;

        [ObservableProperty]
        private bool _hasFeedback;
        public FeedbackPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task CheckIfHasFeedback()
        {
            var feedback = await _context.GetFileteredAsync<Feedback>(f => f.OrderId == OrderId);
            if(feedback.Any())
            {
                HasFeedback= true;
                foreach(var item in feedback)
                {
                    Rate = item.Rate;
                    FeedbackText = item.Text;
                }
            }
            else
            {
                HasFeedback = false;
            }
            
        }

        [RelayCommand]
        public async Task LeaveFeedback()
        {
            Feedback feedback = new Feedback(CurrentUser.CurrentClient.Name, Rate+1, FeedbackText,OrderId);
            await _context.AddItemAsync<Feedback>(feedback);
            await Shell.Current.DisplayAlert("Notification", "Отзыв отправлен,спасибо!", "Ок");
        }

    }
}
