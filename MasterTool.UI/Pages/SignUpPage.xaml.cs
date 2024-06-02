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
            UsernameAvailabilityLabel.Text = "��� ��������";
            SignupBtn.IsEnabled = true;
            UsernameAvailabilityLabel.TextColor = Colors.Green;
        }
        else
        {
            UsernameAvailabilityLabel.Text = "��� �����";
            SignupBtn.IsEnabled= false;
            UsernameAvailabilityLabel.TextColor = Colors.Red;
        }
    }

    private void OnPasswordChanged(object sender, EventArgs e)
    {
        bool isPasswordOkay = CredentialsChecker.IsPasswordValid(PasswordEntry.Text);
        if (!isPasswordOkay)
        {
            PasswordLabel.Text = "������ ������ ��������� �� ����� 8 ��������, ������� ����� � �����.";
            SignupBtn.IsEnabled = false;
            PasswordLabel.TextColor = Colors.Red;
        }
        else
        {
            PasswordLabel.Text = "OK";
            SignupBtn.IsEnabled = true;
            PasswordLabel.TextColor = Colors.Green;
        }
    }

    private void OnSecondPasswordChanged(object sender, EventArgs e)
    {
        if(SecondPasswordEntry.Text!=PasswordEntry.Text)
        {
            SecondPasswordLabel.Text = "������ �� ���������";
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
            PhoneNumberLabel.Text = "����� �������� ������ ���� � ������� +375-XX-XXXXXXX.";
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
            EmailLabel.Text = "Email ������ ���� � ������� example@gmail.com ��� example@mail.ru.";
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