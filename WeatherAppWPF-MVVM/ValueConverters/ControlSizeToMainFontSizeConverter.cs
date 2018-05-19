using System;
using System.Globalization;
using System.Windows;

namespace WeatherAppWPF_MVVM
{
    public class ControlSizeToMainFontSizeConverter : BaseValueConverter<ControlSizeToMainFontSizeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double controlSize = (double)value;
           // MessageBox.Show(controlSize.ToString());
            if (controlSize > 200)
                return 27;
            else if (controlSize < 100)
            {
                MessageBox.Show(controlSize.ToString());
                return 17;

            }
               
            else
            return 20;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
      
}
