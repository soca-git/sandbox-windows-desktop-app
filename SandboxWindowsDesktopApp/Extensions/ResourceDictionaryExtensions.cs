using Microsoft.Extensions.DependencyInjection;
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
    }
}
