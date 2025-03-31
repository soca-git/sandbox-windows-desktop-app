using System.Windows;
using System.Windows.Input;

namespace SandboxWindowsDesktopApp
{
    /// <summary>
    /// Interaction logic for WindowA.xaml
    /// </summary>
    public partial class WindowA : Window
    {
        public WindowA()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            this.DragMove();
            base.OnMouseLeftButtonDown(e);
        }
    }
}
