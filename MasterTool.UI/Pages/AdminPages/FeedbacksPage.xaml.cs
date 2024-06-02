namespace MasterTool.UI.Pages.AdminPages;

public partial class FeedbacksPage : ContentPage
{
	private FeedbacksPageViewModel viewModel;
	public FeedbacksPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel= new FeedbacksPageViewModel(context);
		BindingContext= viewModel;
	}

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AdminHomePage));
    }
}