namespace MasterTool.UI.Pages;

public partial class EditPersonalDataPage : ContentPage
{
	EditPersonalDataPageViewModel viewModel;
	public EditPersonalDataPage(DatabaseContext context)
    {
        InitializeComponent();
        viewModel = new EditPersonalDataPageViewModel(context);
        BindingContext = viewModel;

        NavigatedFrom += OnNavigatedFrom;
    }

    private async void OnNavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        if (viewModel.User.UserCategory == "Client")
        {
            await Shell.Current.GoToAsync(nameof(ClientHomePage));
        }
        if(viewModel.User.UserCategory == "Master")
        {
            await Shell.Current.GoToAsync(nameof(MasterHomePage));
        }
        if (viewModel.User.UserCategory == "Admin")
        {
            await Shell.Current.GoToAsync(nameof(AdminHomePage));
        }
    }
}