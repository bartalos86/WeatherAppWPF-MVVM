using System.Windows;
using System.Windows.Controls;
using WeatherAppWPF_MVVM.ViewModels;

namespace WeatherAppWPF_MVVM.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage(Window win)
        {
            InitializeComponent();
            this.DataContext = new SettingsPageViewModel(this,win);
        }
    }
}
