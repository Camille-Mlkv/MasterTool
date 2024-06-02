namespace MasterTool.UI.Pages.ClientPages;

public partial class AddNewCardPage : ContentPage
{
	private AddNewCardPageViewModel viewModel;
	public AddNewCardPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new AddNewCardPageViewModel(context);
		BindingContext=viewModel;
	}
	private void OnNumberChanged(object sender, TextChangedEventArgs e)
	{
        var entry = sender as Entry;
        if (entry == null)
            return;

        var text = e.NewTextValue;
        if (string.IsNullOrWhiteSpace(text))
            return;

        text = text.Replace(" ", string.Empty);
        text = new string(text.Where(char.IsDigit).ToArray());

        if (text.Length > 16)
        {
            text = text.Substring(0, 16);
        }

        var formattedText = string.Empty;
        for (int i = 0; i < text.Length; i++)
        {
            if (i > 0 && i % 4 == 0)
                formattedText += " ";

            formattedText += text[i];
        }

        entry.Text = formattedText;
        
    }

    private void OnCvcChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        if (entry == null)
            return;

        var text = e.NewTextValue;
        if (string.IsNullOrWhiteSpace(text))
            return;

        text = new string(text.Where(char.IsDigit).ToArray());

        if (text.Length > 3)
        {
            text = text.Substring(0, 3);
        }

        entry.Text = text;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ClientHomePage));
    }
}