using MasterTool.UI.Pages;
using MasterTool.UI.ViewModels;
using MAUISql.Data;

namespace MasterTool.UI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }

        private async void OnLogInClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(LogInPage));
        }
    }
}