namespace MasterTool.UI.Pages.AdminPages;

public partial class CheckServicesPage : ContentPage
{
	private CheckServicesPageViewModel viewModel;
	public CheckServicesPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new CheckServicesPageViewModel(context);
		BindingContext = viewModel;
	}
}