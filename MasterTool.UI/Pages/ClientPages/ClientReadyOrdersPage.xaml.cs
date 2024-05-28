using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace MasterTool.UI.Pages.ClientPages;

public partial class ClientReadyOrdersPage : ContentPage
{
	private ClientReadyOrdersPageViewModel viewModel;

    public ClientReadyOrdersPage(DatabaseContext context)
	{
		InitializeComponent();
		viewModel = new ClientReadyOrdersPageViewModel(context);
		BindingContext = viewModel;
	}

}