using MasterTool.UI.ViewModels.ClientViewModels;
using MAUISql.Data;

namespace MasterTool.UI.Pages.ClientPages;

public partial class NotificationsPage : ContentPage
{
	private NotificationsPageViewModel viewModel;
	public NotificationsPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new NotificationsPageViewModel(context);
		BindingContext= viewModel;

		NavigatedFrom += OnNavigatedFrom;
	}

    private async void OnNavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(ClientHomePage));
    }
}