using System.Media;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace SandboxWindowsDesktopApp.ViewModels
{
    public class MainWindowViewModel
    {
        private CancellationTokenSource counterToken = new();

        public MainWindowViewModel()
        {
            this.BeepCommand = new RelayCommand(() => SystemSounds.Beep.Play(), () => true);
            this.InactiveCommand = new RelayCommand(() => {}, () => false);

            this.StartCounterCommand = new AsyncRelayCommand(async () =>
            {
                this.counterToken = new();

                while (!this.counterToken.IsCancellationRequested)
                {
                    this.Counter++;

                    try
                    {
                        await Task.Delay(1000, this.counterToken.Token);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                }

                await Task.CompletedTask;
            });

            this.StopCounterCommand = new RelayCommand(() =>
            {
                this.counterToken.Cancel();
            }, () => !this.StartCounterCommand.CanExecute(null));
        }

        public event EventHandler StateChanged;

        public ICommand BeepCommand { get; init; }
        public ICommand InactiveCommand { get; init; }

        public ICommand StartCounterCommand { get; init; }

        public ICommand StopCounterCommand { get; init; }

        public string SomeText => $"This is a some sample text from the {nameof(MainWindowViewModel)}";

        public int Counter { get; private set; }
    }
}
