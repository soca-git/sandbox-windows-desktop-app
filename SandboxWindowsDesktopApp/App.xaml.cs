using Microsoft.Extensions.DependencyInjection;
using SandboxWindowsDesktopApp.Extensions;
using SandboxWindowsDesktopApp.ViewModels.Extensions;
using System.Windows;

namespace SandboxWindowsDesktopApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private ServiceProvider? serviceProvider;

    public App()
    {
        this.Startup += App_Startup;
        this.Exit += App_Exit;

        this.ShutdownMode = ShutdownMode.OnMainWindowClose;
    }

    private void App_Startup(object sender, StartupEventArgs e)
    {
        ServiceCollection serviceCollection = new();
        serviceCollection
            .AddRazorComponentsSupport()
            .ConfigureViewModels()
            .AddBlazorBootstrap(); // third party bootstrap components

        this.serviceProvider = serviceCollection.BuildServiceProvider();

        Resources.AddRazorComponentsSupport(this.serviceProvider);
        Resources.ConfigureViewModelsForXamlInjection(this.serviceProvider);
    }

    private void App_Exit(object sender, ExitEventArgs e)
    {
        this.serviceProvider?.Dispose();
    }
}
