using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace WeatherAppWPF_MVVM
{
    [JsonObject]
    public class LanguageDataModel
    {
        [JsonProperty]
        public string LanguageName { get; set; }
        [JsonProperty]
        public string IconPath { get; set; }

        [JsonProperty]
        public string[] Days { get; set; }
        [JsonProperty]
        public string Temperature { get; set; }
        [JsonProperty]
        public string WindSpeed { get; set; }
        [JsonProperty]
        public string SearchText { get; set; }
        [JsonProperty]
        public string LocationSearchText { get; set; }
        [JsonProperty]
        public string SettingsText { get; set; }

        [JsonProperty]
        public string SettingsLanguage { get; set; }
        [JsonProperty]
        public string SettingsUnit { get; set; }
        [JsonProperty]
        public string SettingsHome { get; set; }
        [JsonProperty]
        public string SettingsSave { get; set; }
        [JsonProperty]
        public string SettingsCancel { get; set; }

        [JsonProperty]
        public Dictionary<string,string> WeatherDescribtions { get; set; }

        [JsonConstructor]
        public LanguageDataModel()
        {
            LanguageName = "English";
            IconPath = "pack://application:,,,/Images/LanguageIcons/unknown.png";
            Days = new string[] { "Sunday", "Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"};
            LocationSearchText = "Search Location";
            Temperature = "Temperature";
            WindSpeed = "Wind speed";
            SearchText = "Search";
            SettingsText = "Settings";
            SettingsLanguage = "Language";
            SettingsUnit = "Unit";
            SettingsHome = "Home Location";
            SettingsSave = "Save";
            SettingsCancel = "Cancel";
            WeatherDescribtions = new Dictionary<string, string>();
            WeatherDescribtions.Add("rain", "rain");
            WeatherDescribtions.Add("heavy intensity rain", "Heavy intensity rain");
            WeatherDescribtions.Add("scattered clouds", "Scattered clouds");
            WeatherDescribtions.Add("light", "Light");
            WeatherDescribtions.Add("moderate", "Moderate");
            WeatherDescribtions.Add("heavy", "Heavy");
            WeatherDescribtions.Add("sky is clear", "Sky is clear");
            WeatherDescribtions.Add("snow", "snow");

        }


    }
}
