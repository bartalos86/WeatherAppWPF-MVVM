using System;
using System.Globalization;
using WeatherAppWPF_MVVM.Pages;

namespace WeatherAppWPF_MVVM
{
    class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.MainWeather:
                    return new MainWeatherPage();
                   
              //  case ApplicationPage.SettingsMenu:
                   // return new SettingsPage();
                    
                default:
                    return null;   
            }
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
