using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WeatherAppWPF_MVVM
{
    class TextToImageConverter : BaseValueConverter<TextToImageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //string imageName = string.Format("./Images/Wallpapers/{0}wp.jpg", value);
            //Uri baseUri = ProxyFactory.GetUriFromLocalPath();

            //BitmapImage img = BitmapImage.Create((string)value);
            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
