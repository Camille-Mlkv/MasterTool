namespace MasterTool.UI.Pages;

public partial class SignUpPage : ContentPage
{
    private SignUpPageViewModel viewModel;
    public SignUpPage(DatabaseContext context)
    {
        InitializeComponent();
        viewModel=new SignUpPageViewModel(context);
        BindingContext=viewModel;
    }

    private async void OnBack(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }

    private void OnRBChecked(object sender, CheckedChangedEventArgs e)
    {
        KeyEntry.IsVisible = true;
        if (sender == MasterRB && MasterRB.IsChecked)
        {
            ((SignUpPageViewModel)BindingContext).UserType = "Master";
        }
        if (sender == AdminRB && AdminRB.IsChecked)
        {
            ((SignUpPageViewModel)BindingContext).UserType = "Admin";
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        KeyEntry.IsVisible = false;
        UsernameAvailabilityLabel.Text = "";
        await viewModel.LoadAllUsernames();

    }

    private void OnUsernameChanged(object sender, EventArgs e)
    {
        if (viewModel.UsernameIsUnique(UsernameEntry.Text))
        {
            UsernameAvailabilityLabel.Text = "Ник свободен";
            SignupBtn.IsEnabled = true;
        }
        else
        {
            UsernameAvailabilityLabel.Text = "Ник занят";
            SignupBtn.IsEnabled= false;
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        MasterRB.IsChecked = false;
        AdminRB.IsChecked = false;

    }
}