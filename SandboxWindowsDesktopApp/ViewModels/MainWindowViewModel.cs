using System.Media;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace SandboxWindowsDesktopApp.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            this.ButtonA = new RelayCommand(() => SystemSounds.Beep.Play(), () => true);
            this.ButtonB = new RelayCommand(() => SystemSounds.Beep.Play(), () => false);
            this.ButtonC = new RelayCommand(() => SystemSounds.Beep.Play(), () => true);
        }

        public ICommand ButtonA { get; init; }
        public ICommand ButtonB { get; init; }
        public ICommand ButtonC { get; init; }

        public string SomeText => $"This is a some sample text from the {nameof(MainWindowViewModel)}";
    }
}
