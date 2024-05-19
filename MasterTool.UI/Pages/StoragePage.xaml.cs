namespace MasterTool.UI.Pages.AdminPages;

public partial class StoragePage : ContentPage
{
	public StoragePage()
	{
		InitializeComponent();
		BindingContext = new StoragePageViewModel();
	}
}