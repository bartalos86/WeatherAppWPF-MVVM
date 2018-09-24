using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Text;
using System.Windows;

namespace WeatherAppWPF_MVVM.Functions
{
    public static class WeatherGetter
    {
        private static WebClient webClient = new WebClient();

        public static WeatherDataModel GetWeatherData(string locationName,LanguageDataModel currentLang, string unit)
        {
            if(locationName != string.Empty)
            {

                // MessageBox.Show(unit);
                string unitSystem;
                if (unit.Equals("Celsius"))
                {
                    unitSystem = "metric";
                }
                else
                {
                    unitSystem = "imperial";
                }



                string webAddress = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={locationName}&mode=json&units={unitSystem}&cnt=7&appid=d0f9a1cee42be9d3f4c06858437cd28b";
                string response;
                WeatherDataModel outputWeatherData;
                dynamic JsonObjectData;
                
                try
                {
                    response = webClient.DownloadString(webAddress);

                    if (response.Length < 55)
                        return null;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return null;
                }
              //  outputWeatherData
                JsonObjectData = JObject.Parse(response);
                //string asd = JsonObjectData.list[0].temp.day;
                //MessageBox.Show(asd);
                outputWeatherData = new WeatherDataModel()
                {
                    TodayTemp = JsonObjectData.list[0].temp.day,
                    MinimumTemp = JsonObjectData.list[0].temp.min,
                    MaximumTemp = JsonObjectData.list[0].temp.max,
                    WindSpeed = JsonObjectData.list[0].speed,
                    ImageName = JsonObjectData.list[0].weather[0].main,
                    Pressure = JsonObjectData.list[0].pressure,
                    LocationCity = JsonObjectData.city.name,

                };
                outputWeatherData.Days = new DailyWeather[6];
                for (int i =0; i <= 5; i++)
                {
                    StringBuilder describtion = new StringBuilder();
                    describtion.Append((string)JsonObjectData.list[i + 1].weather[0].description);
                    describtion.Replace("heavy intensity rain", currentLang.WeatherDescribtions["heavy intensity rain"]);
                    describtion.Replace("scattered clouds", currentLang.WeatherDescribtions["scattered clouds"]);
                    describtion.Replace("light", currentLang.WeatherDescribtions["light"]);
                    describtion.Replace("moderate", currentLang.WeatherDescribtions["moderate"]);
                    describtion.Replace("heavy", currentLang.WeatherDescribtions["heavy"]);
                    describtion.Replace("rain", currentLang.WeatherDescribtions["rain"]);
                    describtion.Replace("snow", currentLang.WeatherDescribtions["snow"]);
                    describtion.Replace("sky is clear", currentLang.WeatherDescribtions["sky is clear"]);
                   

                    outputWeatherData.Days[i] = new DailyWeather(describtion.ToString(), (int)JsonObjectData.list[i + 1].temp.min,
                        (int)JsonObjectData.list[i + 1].temp.max, (string)JsonObjectData.list[i + 1].weather[0].main);
                }
               
               

                return outputWeatherData;

            }

            return null;
        }


    }
}
