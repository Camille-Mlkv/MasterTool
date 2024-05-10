using MasterTool.UI.Pages;
using MasterTool.UI.Pages.ClientPages;

namespace MasterTool.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SignUpPage),typeof(SignUpPage));
            Routing.RegisterRoute(nameof(LogInPage),typeof(LogInPage));
            Routing.RegisterRoute(nameof(ClientHomePage),typeof(ClientHomePage));
            Routing.RegisterRoute(nameof(EditPersonalDataPage),typeof(EditPersonalDataPage));
            Routing.RegisterRoute(nameof(CreateRequestPage),typeof(CreateRequestPage));
            Routing.RegisterRoute(nameof(RequestsListPage), typeof(RequestsListPage));
            Routing.RegisterRoute(nameof(NotApprovedRequestsPage), typeof(NotApprovedRequestsPage));
            Routing.RegisterRoute(nameof(OrdersInProcessPage), typeof(OrdersInProcessPage));
            Routing.RegisterRoute(nameof(OrderDetailsPage), typeof(OrderDetailsPage));
        }
    }
}