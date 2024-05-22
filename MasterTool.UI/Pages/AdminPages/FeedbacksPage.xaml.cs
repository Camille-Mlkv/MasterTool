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
}