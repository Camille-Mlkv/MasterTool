namespace MasterTool.UI.Pages;

public partial class DetailsPage : ContentPage
{
	private DetailsPageViewModel viewModel;
	public DetailsPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new DetailsPageViewModel(context);
		BindingContext=viewModel;
	}
}