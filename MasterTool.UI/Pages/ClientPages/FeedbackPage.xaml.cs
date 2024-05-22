namespace MasterTool.UI.Pages.ClientPages;

public partial class FeedbackPage : ContentPage
{
	private FeedbackPageViewModel viewModel;
	public FeedbackPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new FeedbackPageViewModel(context);
		BindingContext=viewModel;
	}
}