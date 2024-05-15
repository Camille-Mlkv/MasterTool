namespace MasterTool.UI.Pages.MasterPages;

public partial class MasterReadyOrdersPage : ContentPage
{
	private MasterReadyOrdersPageViewModel viewModel;
	public MasterReadyOrdersPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new MasterReadyOrdersPageViewModel(context);
		BindingContext = viewModel;
	}
}