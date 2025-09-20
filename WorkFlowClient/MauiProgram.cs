using Microsoft.Extensions.Logging;
using WorkFlowClient.Services.Class;
using WorkFlowClient.Services.Interfaces;

namespace WorkFlowClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddSingleton<LangState>();

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<IShiftService, ShiftService>();
            builder.Services.AddHttpClient("Server", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7246/api/");//https://hairbello.site
              
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
