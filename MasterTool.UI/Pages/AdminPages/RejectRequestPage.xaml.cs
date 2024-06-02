namespace MasterTool.UI.Pages.AdminPages;

public partial class RejectRequestPage : ContentPage
{
	private RejectRequestPageViewModel viewModel;
	public RejectRequestPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new RejectRequestPageViewModel(context);
		BindingContext=viewModel;
	}
}