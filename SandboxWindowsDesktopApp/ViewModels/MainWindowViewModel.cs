﻿using System.ComponentModel;
using System.Diagnostics;
using System.Media;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace SandboxWindowsDesktopApp.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private WindowA? windowA;
        private WindowB? windowB;
        private string someText;
        private int counter;
        private bool counterActive;
        private CancellationTokenSource counterToken = new();

        public MainWindowViewModel()
        {
            this.BeepCommand = new RelayCommand(() =>
            {
                SystemSounds.Beep.Play();
            });

            this.OpenWindowA = new RelayCommand(() =>
            {
                this.windowA ??= new();
                this.windowA.Show();
            }, () => !this.windowA?.IsVisible ?? true);

            this.OpenWindowB = new RelayCommand(() =>
            {
                this.windowB ??= new();
                this.windowB.Show();
            }, () => !this.windowB?.IsVisible ?? true);

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

            this.someText = $"This is a some sample text from the {nameof(MainWindowViewModel)}";

            this.ModelInitialized += MainWindowViewModel_ModelInitialized;
            this.ModelInitialized.Invoke(this, new());
            Debug.WriteLine("Done");
        }

        private async void MainWindowViewModel_ModelInitialized(object? sender, EventArgs e)
        {
            await Task.Delay(10000);
            Debug.WriteLine("Done here");
        }

        public event EventHandler? ModelInitialized;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand BeepCommand { get; init; }

        public ICommand OpenWindowA { get; init; }

        public ICommand OpenWindowB { get; init; }

        public ICommand InactiveCommand { get; init; }

        public ICommand StartCounterCommand { get; init; }

        public string SomeText
        {
            get => this.someText;
            set
            {
                this.someText = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SomeText)));
            }
        }

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
