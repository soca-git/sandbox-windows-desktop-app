using Microsoft.Extensions.DependencyInjection;
using SandboxWindowsDesktopApp.Extensions;
using SandboxWindowsDesktopApp.ViewModels.Extensions;
using System.Windows;

namespace SandboxWindowsDesktopApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        ServiceCollection serviceCollection = new();
        serviceCollection
            .AddRazorComponentsSupport()
            .ConfigureViewModels();

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

        Resources.AddRazorComponentsSupport(serviceProvider);
    }
}
