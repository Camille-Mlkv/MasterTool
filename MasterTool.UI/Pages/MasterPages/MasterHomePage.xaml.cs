namespace MasterTool.UI.Pages.MasterPages;

public partial class MasterHomePage : ContentPage
{
	private MasterHomePageViewModel viewModel;
	public MasterHomePage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new MasterHomePageViewModel(context);
		BindingContext = viewModel;
		
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        GreetingLbl.Text = viewModel.PrintGreeting();
    }
}