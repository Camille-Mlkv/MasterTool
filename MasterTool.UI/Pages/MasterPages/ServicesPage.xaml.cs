using MasterTool.UI.ViewModels.MasterViewModels;
using MAUISql.Data;

namespace MasterTool.UI.Pages.MasterPages;

public partial class ServicesPage : ContentPage
{
	private ServicesPageViewModel viewModel;
	public ServicesPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new ServicesPageViewModel(context);
		BindingContext = viewModel;
	}
}