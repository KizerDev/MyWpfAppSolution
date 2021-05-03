using Prism.Regions;
using System.Windows;

namespace MyWpfAppDemo.Shell
{
    /// <summary>
    /// Logique d'interaction pour ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : Window
    {
        public ShellWindow(IRegionManager regionManager)
        {
            InitializeComponent();
        }
    }
}
