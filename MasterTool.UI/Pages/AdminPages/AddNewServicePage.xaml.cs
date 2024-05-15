using MasterTool.UI.ViewModels.AdminViewModels;

namespace MasterTool.UI.Pages.AdminPages;

public partial class AddNewServicePage : ContentPage
{
	private AddNewServicePageViewModel viewModel;
	public AddNewServicePage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new AddNewServicePageViewModel(context);
		BindingContext = viewModel;
		NavigatedFrom += OnNavigatedFrom;
	}

    private async void OnNavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(AdminHomePage));
    }
}