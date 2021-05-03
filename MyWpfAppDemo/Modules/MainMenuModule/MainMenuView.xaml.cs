using System.Windows.Controls;

namespace MyWpfAppDemo.Modules.MainMenuModule
{
    /// <summary>
    /// Logique d'interaction pour MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        public MainMenuView(MainMenuViewModel viewmodel)
        {
            InitializeComponent();
            DataContext = viewmodel;
        }
    }
}
