using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MasterToolPersistence;
using Syncfusion.Maui.Core.Hosting;

namespace MasterTool.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).UseMauiCommunityToolkit();


            string connectionString = Path.Combine(FileSystem.AppDataDirectory, "MasterToolDatabase.db3");
            builder.Services.AddPersistence(connectionString)
                             .RegisterPages()
                             .RegisterViewModels()
                             .RegisterClientPages()
                             .RegisterClientViewModels()
                             .RegisterMasterPages()
                             .RegisterMasterViewModels()
                             .RegisterAdminPages()
                             .RegisterAdminViewModels();
            
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}