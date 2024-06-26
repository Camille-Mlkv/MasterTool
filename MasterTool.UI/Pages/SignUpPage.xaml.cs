using MasterTool.UI.Services;
using System.Text.RegularExpressions;

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

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        MasterRB.IsChecked = false;
        AdminRB.IsChecked = false;

    }

    private void OnUsernameChanged(object sender, EventArgs e)
    {
        if (viewModel.UsernameIsUnique(UsernameEntry.Text))
        {
            UsernameAvailabilityLabel.Text = "Username is free.";
            SignupBtn.IsEnabled = true;
            UsernameAvailabilityLabel.TextColor = Colors.Green;
        }
        else
        {
            UsernameAvailabilityLabel.Text = "Username is taken.";
            SignupBtn.IsEnabled= false;
            UsernameAvailabilityLabel.TextColor = Colors.Red;
        }
    }

    private void OnPasswordChanged(object sender, EventArgs e)
    {
        bool isPasswordOkay = CredentialsChecker.IsPasswordValid(PasswordEntry.Text);
        if (!isPasswordOkay)
        {
            PasswordLabel.Text = "Password must contain at least 8 symbols, including digits and letters.";
            SignupBtn.IsEnabled = false;
            PasswordLabel.TextColor = Colors.Red;
        }
        else
        {
            PasswordLabel.Text = "Great password!";
            SignupBtn.IsEnabled = true;
            PasswordLabel.TextColor = Colors.Green;
        }
    }

    private void OnSecondPasswordChanged(object sender, EventArgs e)
    {
        if(SecondPasswordEntry.Text!=PasswordEntry.Text)
        {
            SecondPasswordLabel.Text = "Passwords must match!";
            SignupBtn.IsEnabled = false;
            SecondPasswordLabel.TextColor= Colors.Red;
        }
        else
        {
            SecondPasswordLabel.Text = "";
            SignupBtn.IsEnabled = true;
        }
    }

    private void OnPhoneNumberChanged(object sender, TextChangedEventArgs e)
    {
        bool isPhoneNumberValid = CredentialsChecker.IsPhoneNumberValid(e.NewTextValue);
        if (!isPhoneNumberValid)
        {
            PhoneNumberLabel.Text = "Phone number must be formatted as follows: +375-XX-XXXXXXX.";
            PhoneNumberLabel.TextColor = Colors.Red;
            SignupBtn.IsEnabled = false;
        }
        else
        {
            PhoneNumberLabel.Text = "OK.";
            PhoneNumberLabel.TextColor = Colors.Green;
            SignupBtn.IsEnabled = true;
        }
    }

    private void OnEmailChanged(object sender, TextChangedEventArgs e)
    {
        bool isEmailValid = CredentialsChecker.IsEmailValid(e.NewTextValue);
        if (!isEmailValid)
        {
            EmailLabel.Text = "Email must be formatted as follows: example@gmail.com or example@mail.ru.";
            EmailLabel.TextColor = Colors.Red;
            SignupBtn.IsEnabled = false;
        }
        else
        {
            EmailLabel.Text = "OK.";
            EmailLabel.TextColor = Colors.Green;
            SignupBtn.IsEnabled = true;
        }
    }

}