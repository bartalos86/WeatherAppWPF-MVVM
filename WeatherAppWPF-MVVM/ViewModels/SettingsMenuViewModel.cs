
using System.Windows;
using WeatherAppWPF_MVVM.Pages;
using WeatherAppWPF_MVVM.ViewModels;

namespace WeatherAppWPF_MVVM
{
    public class SettingsMenuViewModel : MainWindowViewModel
    {
        Window mWindow;
        public SettingsMenuViewModel(Window win) : base(win)
        {
            mWindow = win;
            //CurrentPage = ApplicationPage.SettingsMenu;
            CurrentPageObject = new SettingsPage(win);
        }

        #region Properties
        //Dependency injectionnal
        public string Title { get; set; }
        public SettingsPage CurrentPageObject { get; set; }
        #endregion

    }
}
