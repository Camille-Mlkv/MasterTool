using MasterTool.UI.ViewModels.MasterViewModels;

namespace MasterTool.UI.Pages.MasterPages;

public partial class OrderDetailsMasterPage : ContentPage
{
	OrderDetailsMasterPageViewModel viewModel;
	public OrderDetailsMasterPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new OrderDetailsMasterPageViewModel(context);
		BindingContext= viewModel;

	}
}