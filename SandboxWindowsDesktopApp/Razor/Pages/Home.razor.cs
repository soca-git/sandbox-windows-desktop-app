using SandboxWindowsDesktopApp.ViewModels;

namespace SandboxWindowsDesktopApp.Razor.Pages
{
    public partial class Home
    {
        public Home(MainWindowViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public MainWindowViewModel ViewModel { get; }
    }
}
