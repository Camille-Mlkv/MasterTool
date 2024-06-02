namespace MasterTool.UI.Pages.AdminPages;

public partial class RequestsToConfirmPage : ContentPage
{
	private RequestsToConfirmPageViewModel viewModel;
	public RequestsToConfirmPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new RequestsToConfirmPageViewModel(context);
		BindingContext=viewModel;
    }
}