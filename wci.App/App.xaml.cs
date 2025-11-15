using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using wci.App.Services;
using wci.App.ViewModels;
using wci.App.Views;

namespace wci.App;

internal sealed partial class App : Application
{
    private static readonly IHost _host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ILuCIService, LuCIService>();

            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddTransient<ErrorPage>();

            services.AddTransient<LoginPage>();
            services.AddTransient<LoginPageViewModel>();

            services.AddTransient<OverviewPage>();
            services.AddTransient<OverviewPageViewModel>();
        }).Build();

    protected override void OnStartup(StartupEventArgs e)
    {
        var currentDomain = AppDomain.CurrentDomain;
        currentDomain.UnhandledException += new UnhandledExceptionEventHandler(ErrorHandler);

        _host.Start();
        _host.Services.GetRequiredService<MainWindow>().Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        _host.Services.GetRequiredService<ILuCIService>()?.Logout();
        await _host!.StopAsync();

        base.OnExit(e);
    }

    static void ErrorHandler(object sender, UnhandledExceptionEventArgs args)
    {
        if (args.ExceptionObject is Exception e)
        {
            Console.WriteLine("Error caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
        }

        _host.Services.GetRequiredService<ILuCIService>()?.Logout();

        // TODO: Error handling
    }
}
