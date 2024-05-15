namespace MasterTool.UI.Pages.ClientPages;

public partial class ClientHomePage : ContentPage
{
	private ClientHomePageViewModel viewModel;
	public ClientHomePage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel= new ClientHomePageViewModel(context);
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        GreetingLbl.Text=viewModel.PrintGreeting();
    }
}