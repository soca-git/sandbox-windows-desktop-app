using Microsoft.Extensions.DependencyInjection;

namespace SandboxWindowsDesktopApp.ViewModels.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static ServiceCollection ConfigureViewModels(this ServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<FormWindowViewModel>();

            return services;
        }
    }
}
