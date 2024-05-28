namespace MasterTool.UI.Pages.ClientPages;

public partial class ChoosePaymentMethodPage : ContentPage
{
	private ChoosePaymentMethodPageViewModel viewModel;
	public ChoosePaymentMethodPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new ChoosePaymentMethodPageViewModel(context);
		BindingContext=viewModel;
	}
}