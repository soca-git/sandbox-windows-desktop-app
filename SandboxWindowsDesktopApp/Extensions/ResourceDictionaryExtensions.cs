using Microsoft.Extensions.DependencyInjection;
using SandboxWindowsDesktopApp.ViewModels;
using System.Windows;

namespace SandboxWindowsDesktopApp.Extensions
{
    internal static class ResourceDictionaryExtensions
    {
        public static ResourceDictionary AddRazorComponentsSupport(this ResourceDictionary resources, ServiceProvider services)
        {
            resources.Add("services", services);

            return resources;
        }

        public static ResourceDictionary ConfigureViewModelsForXamlInjection(this ResourceDictionary resources, ServiceProvider services)
        {
            resources.Add("MainWindowViewModel", services.GetRequiredService<MainWindowViewModel>());

            return resources;
        }
    }
}
