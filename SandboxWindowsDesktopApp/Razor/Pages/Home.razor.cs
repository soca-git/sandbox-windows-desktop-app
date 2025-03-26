using SandboxWindowsDesktopApp.ViewModels;

namespace SandboxWindowsDesktopApp.Razor.Pages
{
    public partial class Home
    {
        public Home(MainWindowViewModel viewModel)
        {
            this.ViewModel = viewModel;

            // temporary render loop
            Task.Run(async () =>
            {
                while (true)
                {
                    await this.InvokeAsync(StateHasChanged);
                    await Task.Delay(1000);
                }
            });
        }

        public MainWindowViewModel ViewModel { get; }
    }
}
