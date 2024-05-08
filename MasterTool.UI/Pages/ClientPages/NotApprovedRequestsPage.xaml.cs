using MasterTool.UI.ViewModels.ClientViewModels;
using MAUISql.Data;

namespace MasterTool.UI.Pages.ClientPages;

public partial class NotApprovedRequestsPage : ContentPage
{
	private NotApprovedRequestsPageViewModel viewModel;
	public NotApprovedRequestsPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new NotApprovedRequestsPageViewModel(context);
		BindingContext = viewModel;

        NavigatedFrom += OnNavigatedFrom;
    }

    private async void OnNavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ClientHomePage));
    }
}