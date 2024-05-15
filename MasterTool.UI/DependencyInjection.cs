

namespace MasterTool.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient<SignUpPage>()
                    .AddTransient<LogInPage>()
                    .AddTransient<EditPersonalDataPage>();
            return services;
        }
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<SignUpPageViewModel>()
                    .AddTransient<LogInPageViewModel>()
                    .AddTransient<EditPersonalDataPageViewModel>();
            return services;
        }

        public static IServiceCollection RegisterClientPages(this IServiceCollection services)
        {
            services.AddTransient<ClientHomePage>()
                    .AddTransient<CreateRequestPage>()
                    .AddTransient<RequestsListPage>()
                    .AddTransient<NotApprovedRequestsPage>()
                    .AddTransient<OrdersInProcessPage>()
                    .AddTransient<OrderDetailsPage>()
                    .AddTransient<NotificationsPage>()
                    .AddTransient<ClientReadyOrdersPage>();
            return services;
        }

        public static IServiceCollection RegisterClientViewModels(this IServiceCollection services)
        {
            services.AddTransient<ClientHomePageViewModel>()
                    .AddTransient<CreateRequestPageViewModel>()
                    .AddTransient<RequestsListPageViewModel>()
                    .AddTransient<NotApprovedRequestsPageViewModel>()
                    .AddTransient<OrdersInProcessPageViewModel>()
                    .AddTransient<OrderDetailsPageViewModel>()
                    .AddTransient<NotificationsPageViewModel>()
                    .AddTransient<ClientReadyOrdersPageViewModel>();
            return services;
        }

        public static IServiceCollection RegisterMasterPages(this IServiceCollection services)
        {
            services.AddTransient<MasterHomePage>()
                    .AddTransient<ServicesPage>()
                    .AddTransient<ClientsRequestsPage>()
                    .AddTransient<OrdersInProcessMasterPage>()
                    .AddTransient<OrderDetailsMasterPage>()
                    .AddTransient<MasterReadyOrdersPage>();
            return services;
        }

        public static IServiceCollection RegisterMasterViewModels(this IServiceCollection services)
        {
            services.AddTransient<MasterHomePageViewModel>()
                    .AddTransient<ServicesPageViewModel>()
                    .AddTransient<ClientsRequestsPageViewModel>()
                    .AddTransient<OrdersInProcessMasterPageViewModel>()
                    .AddTransient<OrderDetailsMasterPageViewModel>()
                    .AddTransient<MasterReadyOrdersPageViewModel>();
            return services;
        }

        public static IServiceCollection RegisterAdminPages(this IServiceCollection services)
        {
            services.AddTransient<AdminHomePage>()
                    .AddTransient<RequestsToConfirmPage>()
                    .AddTransient<AddNewServicePage>()
                    .AddTransient<CheckServicesPage>();
            return services;
        }

        public static IServiceCollection RegisterAdminViewModels(this IServiceCollection services)
        {
            services.AddTransient<AdminHomePageViewModel>()
                    .AddTransient<RequestsToConfirmPageViewModel>()
                    .AddTransient<AddNewServicePageViewModel>()
                    .AddTransient<CheckServicesPageViewModel>();
            return services;
        }
    }
}
