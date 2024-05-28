namespace MasterTool.UI.Pages.ClientPages;

public partial class CardsPage : ContentPage
{
	private CardsPageViewModel viewModel;
	public CardsPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new CardsPageViewModel(context);
		BindingContext=viewModel;
	}
}