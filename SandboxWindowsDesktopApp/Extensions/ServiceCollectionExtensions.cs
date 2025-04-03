using Microsoft.Extensions.DependencyInjection;
using Phork.Blazor;

namespace SandboxWindowsDesktopApp.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static ServiceCollection AddRazorComponentsSupport(this ServiceCollection services)
        {
            services.AddWpfBlazorWebView();
            services.AddPhorkBlazorReactivity();

#if DEBUG
            services.AddBlazorWebViewDeveloperTools();
#endif

            return services;
        }
    }
}
