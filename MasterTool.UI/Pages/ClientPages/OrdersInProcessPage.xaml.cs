namespace MasterTool.UI.Pages.ClientPages;

public partial class OrdersInProcessPage : ContentPage
{
    private OrdersInProcessPageViewModel viewModel;
    public OrdersInProcessPage(DatabaseContext context)
	{
		InitializeComponent();
        viewModel = new OrdersInProcessPageViewModel(context);
        BindingContext = viewModel;

        //NavigatedFrom += OnNavigatedFrom;
    }

    //private async void OnNavigatedFrom(object sender, NavigatedFromEventArgs e)
    //{
    //    await Shell.Current.GoToAsync(nameof(ClientHomePage)); //стрелка блокирует распознаватель жестов
    //}
}