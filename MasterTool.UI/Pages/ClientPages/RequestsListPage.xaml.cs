namespace MasterTool.UI.Pages.ClientPages;

public partial class RequestsListPage : ContentPage
{
	RequestsListPageViewModel viewModel;
	public RequestsListPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new RequestsListPageViewModel(context);
		BindingContext=viewModel;

        NavigatedFrom += OnNavigatedFrom;

    }

    private async void OnNavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ClientHomePage));
    }

}