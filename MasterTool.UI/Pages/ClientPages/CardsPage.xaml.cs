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
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ClientHomePage));
    }

}