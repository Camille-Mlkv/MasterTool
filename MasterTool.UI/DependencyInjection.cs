using CommunityToolkit.Maui;
using MasterTool.UI.Pages;
using MasterTool.UI.Pages.ClientPages;
using MasterTool.UI.ViewModels;
using MasterTool.UI.ViewModels.ClientViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient<SignUpPage>()
                    .AddTransient<LogInPage>()
                    .AddTransient<ClientHomePage>()
                    .AddTransient<EditPersonalDataPage>()
                    .AddTransient<CreateRequestPage>()
                    .AddTransient<RequestsListPage>()
                    .AddTransient<NotApprovedRequestsPage>()
                    .AddTransient<OrdersInProcessPage>()
                    .AddTransient<OrderDetailsPage>();
            return services;
        }
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<SignUpPageViewModel>()
                    .AddTransient<LogInPageViewModel>()
                    .AddTransient<ClientHomePageViewModel>()
                    .AddTransient<EditPersonalDataPageViewModel>()
                    .AddTransient<CreateRequestPageViewModel>()
                    .AddTransient<RequestsListPageViewModel>()
                    .AddTransient<NotApprovedRequestsPageViewModel>()
                    .AddTransient<OrdersInProcessPageViewModel>()
                    .AddTransient<OrderDetailsPageViewModel>();
            return services;
        }

    }
}
