using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace WeatherAppWPF_MVVM
{
    public class WeatherDataModel
    {

        public string TodayTemp { get; set; }

        public string MinimumTemp { get; set; }
        public string MaximumTemp { get; set; }
        public string UVIndex { get; set; }
        public string WindSpeed { get; set; }
        public string ImageName { get; set; }
        public string Pressure { get; set; }
        public string LocationCity { get; set; }

        public DailyWeather[] Days { get; set; }
        
    }

    public class DailyWeather
    {

        public DailyWeather(string desc, int min, int max,string imageName)
        {
            Desc = desc;
            Minimum = min.ToString();
            Maximum = max.ToString();
            ImageName = imageName.ToString();
        }

        public string Desc { get; set; }
        public string Minimum { get; set; }
        public string Maximum { get; set; }
        public string ImageName { get; set; }
    }

   
}

