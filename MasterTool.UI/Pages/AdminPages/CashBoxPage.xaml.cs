namespace MasterTool.UI.Pages.AdminPages;

public partial class CashBoxPage : ContentPage
{
	private CashBoxPageViewModel viewModel;
	public CashBoxPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel=new CashBoxPageViewModel(context);
		BindingContext=viewModel;
	}
}