using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.ViewModels.AdminViewModels
{
    public partial class FeedbacksPageViewModel:ObservableObject
    {
        private DatabaseContext _context;

        public ObservableCollection<Feedback> Feedbacks { get; set; } = new();
        public FeedbacksPageViewModel(DatabaseContext context)
        {
            _context = context;
        }

        [RelayCommand]
        public async Task LoadFeedbacks()
        {
            var feedbacks=await _context.GetAllAsync<Feedback>();
            foreach (var feedback in feedbacks)
            {
                Feedbacks.Add(feedback);
            }
        }
        
    }
}
