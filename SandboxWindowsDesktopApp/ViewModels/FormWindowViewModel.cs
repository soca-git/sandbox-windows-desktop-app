
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SandboxWindowsDesktopApp.ViewModels
{
    public class FormWindowViewModel : INotifyPropertyChanged
    {
        private string name = string.Empty;
        private string description = string.Empty;

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(16, MinimumLength=3, ErrorMessage = "Name [3-16 characters]")]
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public string Description
        {
            get => this.description;
            set
            {
                this.description = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
