namespace MasterTool.UI.Pages.AdminPages;

public partial class AdminHomePage : ContentPage
{
	private AdminHomePageViewModel viewModel;
	public AdminHomePage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new AdminHomePageViewModel(context);
		BindingContext=viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        GreetingLbl.Text = viewModel.PrintGreeting();
    }
}