using MasterTool.UI.ViewModels.ClientViewModels;

namespace MasterTool.UI.Pages.ClientPages;

public partial class ClientReadyOrdersPage : ContentPage
{
	private ClientReadyOrdersPageViewModel viewModel;
	public ClientReadyOrdersPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new ClientReadyOrdersPageViewModel(context);
		BindingContext = viewModel;
	}
}