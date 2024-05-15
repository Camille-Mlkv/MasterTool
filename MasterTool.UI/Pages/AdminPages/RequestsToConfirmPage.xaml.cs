using MasterTool.UI.ViewModels.AdminViewModels;

namespace MasterTool.UI.Pages.AdminPages;

public partial class RequestsToConfirmPage : ContentPage
{
	private RequestsToConfirmPageViewModel viewModel;
	public RequestsToConfirmPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new RequestsToConfirmPageViewModel(context);
		BindingContext=viewModel;
        NavigatedFrom += OnNavigatedFrom;
    }
    private async void OnNavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AdminHomePage));
    }
}