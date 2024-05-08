using MasterTool.UI.ViewModels;
using MAUISql.Data;

namespace MasterTool.UI.Pages;

public partial class LogInPage : ContentPage
{
	LogInPageViewModel viewModel;
	public LogInPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new LogInPageViewModel(context);
		BindingContext=viewModel;
	}

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}