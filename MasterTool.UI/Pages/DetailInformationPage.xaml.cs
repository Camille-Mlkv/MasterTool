namespace MasterTool.UI.Pages;

public partial class DetailInformationPage : ContentPage
{
	private DetailInformationPageViewModel viewModel;
	public DetailInformationPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new DetailInformationPageViewModel(context);
		BindingContext=viewModel;
	}
}