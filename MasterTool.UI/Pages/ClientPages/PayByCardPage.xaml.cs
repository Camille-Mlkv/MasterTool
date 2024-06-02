using MasterToolPersistence.Services;

namespace MasterTool.UI.Pages.ClientPages;

public partial class PayByCardPage : ContentPage
{
	private PayByCardPageViewModel viewModel;
	public PayByCardPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new PayByCardPageViewModel(context);
		BindingContext=viewModel;
	}
}