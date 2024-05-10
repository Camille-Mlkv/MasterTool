using MasterTool.UI.ViewModels.ClientViewModels;
using MAUISql.Data;

namespace MasterTool.UI.Pages.ClientPages;

public partial class OrderDetailsPage : ContentPage
{
	private OrderDetailsPageViewModel viewModel;
	public OrderDetailsPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new OrderDetailsPageViewModel(context);
		BindingContext = viewModel;
		//NavigatedFrom += OnNavigatedFrom;

	}

	//private async void OnNavigatedFrom(object sender, NavigatedFromEventArgs e)
	//{
	//	await Shell.Current.GoToAsync(nameof(ClientHomePage));
	//}
}