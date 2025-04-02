using System.Windows;
using System.Windows.Input;

namespace SandboxWindowsDesktopApp
{
    /// <summary>
    /// Interaction logic for WindowB.xaml
    /// </summary>
    public partial class WindowB : Window
    {
        public WindowB()
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
