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
	private async void OnBackBtnClicked(object sender, EventArgs e)
	{
        await Navigation.PopAsync();
    }
}