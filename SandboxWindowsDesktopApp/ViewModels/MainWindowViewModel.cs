using System.ComponentModel;
using System.Media;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace SandboxWindowsDesktopApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int counter;
        private CancellationTokenSource counterToken = new();

        public MainWindowViewModel()
        {
            this.BeepCommand = new RelayCommand(() => SystemSounds.Beep.Play(), () => true);
            this.InactiveCommand = new RelayCommand(() => {}, () => false);

            this.StartCounterCommand = new AsyncRelayCommand(async () =>
            {
                if (this.CounterActive)
                {
                    this.counterToken.Cancel();
                    this.CounterActive = false;
                    return;
                }

                this.counterToken = new();
                this.CounterActive = true;

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
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand BeepCommand { get; init; }
        public ICommand InactiveCommand { get; init; }

        public ICommand StartCounterCommand { get; init; }

        public string SomeText => $"This is a some sample text from the {nameof(MainWindowViewModel)}";

        public int Counter
        {
            get => this.counter;
            set
            {
                this.counter = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));
            }
        }

        public bool CounterActive { get; set; }
    }
}
