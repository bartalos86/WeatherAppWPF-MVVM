using System.Windows;
using System.Windows.Controls;


namespace WeatherAppWPF_MVVM.Controls
{
    /// <summary>
    /// Interaction logic for DailyWeatherControl.xaml
    /// </summary>
    public partial class DailyWeatherControl : UserControl
    {
        public DailyWeatherControl()
        {
              
                InitializeComponent();

            
        }

        #region Properties

        //public static readonly DependencyProperty WeatherDataProperty = DependencyProperty.Register("WeatherData", typeof(ObservableCollection<string>), typeof(DailyWeatherControl), new PropertyMetadata(PropChange));

        //private static void PropChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    DayString = WeatherData[0];
        //    WeatherDesc = WeatherData[1];
        //    TempMin = WeatherData[2];
        //    TempMax = WeatherData[3];
        //    ImagePath = WeatherData[4];
        //}

        //public ObservableCollection<string> WeatherData
        //{
        //    get { return (ObservableCollection<string>)this.GetValue(WeatherDataProperty); }
        //    set { this.SetValue(WeatherDataProperty, value); }
        //}

        //public string DayString { get; set; }
        //public string WeatherDesc { get; set; }
        //public string TempMin { get; set; }
        //public string TempMax { get; set; }
        //public string ImagePath { get; set; }

        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register("Unit", typeof(string), typeof(DailyWeatherControl));
        public string Unit
        {
            get { return (string)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }

        public static readonly DependencyProperty TemperatureTextProperty = DependencyProperty.Register("TemperatureText", typeof(string), typeof(DailyWeatherControl));
        public string TemperatureText
        {
            get { return (string)this.GetValue(TemperatureTextProperty); }
            set { this.SetValue(TemperatureTextProperty, value); }
        }

        public static readonly DependencyProperty DayStringProperty = DependencyProperty.Register("DayString", typeof(string), typeof(DailyWeatherControl));
        public string DayString
        {
            get { return (string)this.GetValue(DayStringProperty); }
            set { this.SetValue(DayStringProperty, value); }
        }

        public static readonly DependencyProperty WeatherImageSourceProperty = DependencyProperty.Register("WeatherImageSource", typeof(string), typeof(DailyWeatherControl));
        public string WeatherImageSource
        {
            get { return (string)this.GetValue(WeatherImageSourceProperty); }
            set { this.SetValue(WeatherImageSourceProperty, value); }
        }



        public static readonly DependencyProperty WeatherDescStringProperty = DependencyProperty.Register("WeatherDescString", typeof(string), typeof(DailyWeatherControl));
        public string WeatherDescString
        {
            get { return (string)this.GetValue(WeatherDescStringProperty); }
            set { this.SetValue(WeatherDescStringProperty, value); }
        }
        public static readonly DependencyProperty MinTemperatureProperty = DependencyProperty.Register("MinTemperature", typeof(string), typeof(DailyWeatherControl));
        public string MinTemperature
        {
            get { return (string)this.GetValue(MinTemperatureProperty); }
            set { this.SetValue(MinTemperatureProperty, value); }
        }
        public static readonly DependencyProperty MaxTemperatureProperty = DependencyProperty.Register("MaxTemperature", typeof(string), typeof(DailyWeatherControl));
        public string MaxTemperature
        {
            get { return (string)this.GetValue(MaxTemperatureProperty); }
            set { this.SetValue(MaxTemperatureProperty, value); }
        }


        #endregion
    }
}
