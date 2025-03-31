using System.ComponentModel;
using System.Media;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace SandboxWindowsDesktopApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private WindowA? windowA;

        private int counter;
        private bool counterActive;
        private CancellationTokenSource counterToken = new();

        public MainWindowViewModel()
        {
            this.BeepCommand = new RelayCommand(() =>
            {
                SystemSounds.Beep.Play();
            });

            this.OpenAnotherWindowCommand = new RelayCommand(() =>
            {
                this.windowA ??= new();
                this.windowA.Show();
            }, () => !this.windowA?.IsVisible ?? true);

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
                        await Task.Delay(500, this.counterToken.Token);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                }

                await Task.CompletedTask;
            }, AsyncRelayCommandOptions.AllowConcurrentExecutions);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand BeepCommand { get; init; }

        public ICommand OpenAnotherWindowCommand { get; init; }

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

        public bool CounterActive
        {
            get => this.counterActive;
            set
            {
                this.counterActive = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CounterActive)));
            }
        }
    }
}
