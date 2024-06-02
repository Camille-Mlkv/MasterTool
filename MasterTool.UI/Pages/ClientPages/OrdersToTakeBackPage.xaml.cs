namespace MasterTool.UI.Pages.ClientPages;

public partial class OrdersToTakeBackPage : ContentPage
{
	private OrdersToTakeBackPageViewModel _viewModel;
	public OrdersToTakeBackPage(DatabaseContext context)
	{
		InitializeComponent();
		_viewModel = new OrdersToTakeBackPageViewModel(context);
		BindingContext= _viewModel;
	}

	private async void OnClearCLicked(object sender, EventArgs e)
	{
		if (SearchingBar.Text == "")
		{
			await _viewModel.LoadOrders();
		}

    }
}