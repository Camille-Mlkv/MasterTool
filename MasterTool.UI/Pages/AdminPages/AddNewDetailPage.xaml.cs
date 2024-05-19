namespace MasterTool.UI.Pages.AdminPages;

public partial class AddNewDetailPage : ContentPage
{
	private AddNewDetailPageViewModel viewModel;
	public AddNewDetailPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new AddNewDetailPageViewModel(context);
		BindingContext=viewModel;
	}
}