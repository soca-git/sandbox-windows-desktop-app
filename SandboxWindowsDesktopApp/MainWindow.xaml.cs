using Microsoft.Extensions.DependencyInjection;
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
        serviceCollection.AddWpfBlazorWebView();

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

        Resources.Add("services", serviceProvider);
    }
}
