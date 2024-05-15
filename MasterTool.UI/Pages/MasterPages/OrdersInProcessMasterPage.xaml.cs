namespace MasterTool.UI.Pages.MasterPages;

public partial class OrdersInProcessMasterPage : ContentPage
{
	private OrdersInProcessMasterPageViewModel viewModel;
	public OrdersInProcessMasterPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new OrdersInProcessMasterPageViewModel(context);
		BindingContext=viewModel;
	}
}