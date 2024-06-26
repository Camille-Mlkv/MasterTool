﻿
namespace MasterTool.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SignUpPage),typeof(SignUpPage));
            Routing.RegisterRoute(nameof(LogInPage),typeof(LogInPage));
            Routing.RegisterRoute(nameof(EditPersonalDataPage), typeof(EditPersonalDataPage));
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage)); 
            Routing.RegisterRoute(nameof(DetailInformationPage), typeof(DetailInformationPage));

            Routing.RegisterRoute(nameof(ClientHomePage),typeof(ClientHomePage));
            Routing.RegisterRoute(nameof(CreateRequestPage),typeof(CreateRequestPage));
            Routing.RegisterRoute(nameof(RequestsListPage), typeof(RequestsListPage));
            Routing.RegisterRoute(nameof(NotApprovedRequestsPage), typeof(NotApprovedRequestsPage));
            Routing.RegisterRoute(nameof(OrdersInProcessPage), typeof(OrdersInProcessPage));
            Routing.RegisterRoute(nameof(OrderDetailsPage), typeof(OrderDetailsPage));
            Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
            Routing.RegisterRoute(nameof(ClientReadyOrdersPage), typeof(ClientReadyOrdersPage));
            Routing.RegisterRoute(nameof(FeedbackPage), typeof(FeedbackPage));
            Routing.RegisterRoute(nameof(AddNewCardPage), typeof(AddNewCardPage));
            Routing.RegisterRoute(nameof(CardsPage), typeof(CardsPage));
            Routing.RegisterRoute(nameof(ChoosePaymentMethodPage), typeof(ChoosePaymentMethodPage));
            Routing.RegisterRoute(nameof(PayByCardPage), typeof(PayByCardPage));
            Routing.RegisterRoute(nameof(OrdersToTakeBackPage), typeof(OrdersToTakeBackPage));

            Routing.RegisterRoute(nameof(MasterHomePage), typeof(MasterHomePage));
            Routing.RegisterRoute(nameof(ServicesPage), typeof(ServicesPage));
            Routing.RegisterRoute(nameof(ClientsRequestsPage), typeof(ClientsRequestsPage));
            Routing.RegisterRoute(nameof(OrdersInProcessMasterPage), typeof(OrdersInProcessMasterPage));
            Routing.RegisterRoute(nameof(OrderDetailsMasterPage), typeof(OrderDetailsMasterPage));
            Routing.RegisterRoute(nameof(MasterReadyOrdersPage), typeof(MasterReadyOrdersPage));

            Routing.RegisterRoute(nameof(AdminHomePage),typeof(AdminHomePage));
            Routing.RegisterRoute(nameof(RequestsToConfirmPage), typeof(RequestsToConfirmPage));
            Routing.RegisterRoute(nameof(AddNewServicePage), typeof(AddNewServicePage));
            Routing.RegisterRoute(nameof(CheckServicesPage), typeof(CheckServicesPage));
            Routing.RegisterRoute(nameof(CashBoxPage), typeof(CashBoxPage));
            Routing.RegisterRoute(nameof(StoragePage), typeof(StoragePage));
            Routing.RegisterRoute(nameof(AddNewDetailPage), typeof(AddNewDetailPage));
            Routing.RegisterRoute(nameof(FeedbacksPage), typeof(FeedbacksPage));
            Routing.RegisterRoute(nameof(RejectRequestPage), typeof(RejectRequestPage));
        }
    }
}