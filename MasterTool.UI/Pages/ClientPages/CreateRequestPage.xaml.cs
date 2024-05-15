namespace MasterTool.UI.Pages.ClientPages;

public partial class CreateRequestPage : ContentPage
{
	private CreateRequestPageViewModel viewModel;
	public CreateRequestPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new CreateRequestPageViewModel(context);
		BindingContext=viewModel;
        NavigatedFrom += OnNavigatedFrom;

    }

    private async void OnNavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ClientHomePage));
    }
}