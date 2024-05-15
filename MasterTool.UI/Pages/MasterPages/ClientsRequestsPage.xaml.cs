namespace MasterTool.UI.Pages.MasterPages;

public partial class ClientsRequestsPage : ContentPage
{
	private ClientsRequestsPageViewModel viewModel;
	public ClientsRequestsPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new ClientsRequestsPageViewModel(context);
		BindingContext = viewModel;
	}
}