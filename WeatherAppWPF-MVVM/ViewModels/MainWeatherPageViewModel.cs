using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WeatherAppWPF_MVVM.Functions;
using WeatherAppWPF_MVVM.ViewModels.Base;
using WeatherAppWPF_MVVM.WindowViews;

namespace WeatherAppWPF_MVVM
{
    public class MainWeatherPageViewModel : BaseViewModel
    {
        private Page mPage;
        //private string _todayTemp;
        //private string _todayMin;
        //private string _todayMax;
        //private string _windSpeed;
        //private string _uVIndex;
        private string _todayImageName = "Snow";
        private string _locationCity;


        public MainWeatherPageViewModel(Page page)
        {
            mPage = page;
            LoadPage();

            SearchCityCommand = new RelayCommand(() => SearchCity(TextboxSearchText));
            SettingsMenuCommand = new RelayCommand(() => {
                SettingsMenu menu = new SettingsMenu();
                SettingsMenuViewModel dataContext = (SettingsMenuViewModel) menu.DataContext;
                dataContext.Title = CurrentLanguage.SettingsText;

                menu.Show();

            });

            mPage.SizeChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(WindowHeight));
            };

            CalculateDayOrder();
           // SearchCity(TextboxSearchText);

        }

        #region Methods

        private void CalculateDayOrder()
        {
            //Kiszamitsa a napok sorrendjet
            #region Nap Calc
            string[] napok = new string[7] { CurrentLanguage.Days[0], CurrentLanguage.Days[1], CurrentLanguage.Days[2],
                CurrentLanguage.Days[3], CurrentLanguage.Days[4], CurrentLanguage.Days[5], CurrentLanguage.Days[6] };
            string[] orderedDays = new string[7];
            int nap = (int)DateTime.Now.DayOfWeek;
            int b = 1;
            int cnap = 0;
            _dayNames = new ObservableCollection<string>() { "unknown", "unknown", "unknown", "unknown", "unknown", "unknown" };
            //Logic for getting the day names in order
            for (int i = 0; i < 6; i++)
            {
                cnap = nap + b;
                if (cnap == 7)
                {
                    b = 0;
                    nap = 0;
                    cnap = 0;
                }

                if (i == 0)
                    DayNames[0] = napok[cnap];
                if (i == 1)
                    DayNames[1] = napok[cnap];
                if (i == 2)
                    DayNames[2] = napok[cnap];
                if (i == 3)
                    DayNames[3] = napok[cnap];
                if (i == 4)
                    DayNames[4] = napok[cnap];
                if (i == 5)
                    DayNames[5] = napok[cnap];
                b++;
            }
            #endregion
        }

        public void SearchCity(string city)
        {
            WeatherDataModel weatherData;
            if (!string.IsNullOrWhiteSpace(city))
                weatherData = WeatherGetter.GetWeatherData(city,CurrentLanguage,Unit);
            else
                weatherData = WeatherGetter.GetWeatherData("Samorin", CurrentLanguage,Unit);

            if (weatherData != null)
                SetupData(weatherData);
           
               // MessageBox.Show("Nagy gond");

        }

        private void SetupData(WeatherDataModel weatherData)
        {
            TodayTemp = weatherData.TodayTemp.ToString();
            TodayMin = weatherData.MinimumTemp.ToString();
            TodayMax = weatherData.MaximumTemp.ToString();
            WindSpeed = weatherData.WindSpeed.ToString();
            TodayImageName = weatherData.ImageName;
            TodayImageIcon = string.Format("pack://application:,,,/Images/Weathers/{0}.png", TodayImageName);
            TodayImageBackground = string.Format("pack://application:,,,/Images/Wallpapers/{0}wp.jpg", TodayImageName);
           // MessageBox.Show(TodayImageName);
            LocationCity = weatherData.LocationCity;


            DailyData = new ObservableCollection<DailyWeather>(weatherData.Days);
        }

        public void LoadPage()
        {
            string saveDir = Directory.GetCurrentDirectory();
            if (!Directory.Exists(saveDir + "/Settings"))
                Directory.CreateDirectory("Settings");

            if (!Directory.Exists(saveDir + "/Languages"))
                Directory.CreateDirectory("Languages");
             
            if(!File.Exists(saveDir + "/Languages/eng.lang"))
            {
                File.Create(saveDir + "/Languages/eng.lang").Close();
                StreamWriter langWriter = new StreamWriter(saveDir + "/Languages/eng.lang");
                langWriter.Write(JsonConvert.SerializeObject(new LanguageDataModel(), Formatting.Indented));
                langWriter.Flush();
                langWriter.Close();
            }

            //if(Directory.GetFiles(saveDir + "/Languages").Length > 1)
            //{
            //    foreach(var file in Directory.GetFiles(saveDir + "/Languages","*.lang"))
            //    {
            //        if (file.Contains("hun"))
            //        {
            //            StreamReader langReader = new StreamReader(file);
            //            string rawObj = langReader.ReadToEnd();
            //            try
            //            {
            //                CurrentLanguage = JsonConvert.DeserializeObject<LanguageDataModel>(rawObj);
            //            }
            //            catch {

            //                CurrentLanguage = new LanguageDataModel();

            //            }

            //        }
            //    }
            //}

            if (File.Exists("Settings/settings.json"))
            {
                StreamReader settingsReader = new StreamReader("Settings/settings.json");

                try
                {
                    SettingsDataModel settings = JsonConvert.DeserializeObject<SettingsDataModel>(settingsReader.ReadToEnd());
                    CurrentLanguage = settings.SelectedLanguage;
                    Unit = settings.Unit;
                    UnitSymbol = Unit.Substring(0, 1);

                    if (Unit.Equals("Celsius"))
                        UnitSymbolSpeed = "km/h";
                    else
                        UnitSymbolSpeed = "mp/h";

                        SearchCity(settings.HomeLocation);
                    
                    
                }
                catch (Exception)
                {

                }
            }
            else
                CurrentLanguage = new LanguageDataModel();
               

        }

        #endregion

        #region Properties

        public double WindowHeight { get { return mPage.Height; } }
        public string TextboxSearchText { get; set; }
        public LanguageDataModel CurrentLanguage { get; set; } = new LanguageDataModel();

        public string Unit { get; set; }
        public string UnitSymbol { get; set; }
        public string UnitSymbolSpeed { get; set; }

        public string TodayTemp { get; set; }
        public string TodayMin { get; set; }
        public string TodayMax { get; set; }
        public string WindSpeed { get; set; }
        public string UVIndex { get; set; }
        public string TodayImageName { get => _todayImageName; set { _todayImageName = value; OnPropertyChanged(nameof(TodayImageName)); } }
        public string LocationCity { get => _locationCity; set { _locationCity = value; OnPropertyChanged(nameof(LocationCity)); } }
        public string TodayImageBackground { get; set; }
        public string TodayImageIcon { get; set; }

        private ObservableCollection<string> _dayNames;

        public ObservableCollection<string> DayNames
        {
            get { return _dayNames; }
            set { _dayNames = value; }
        }




        private ObservableCollection<DailyWeather> _dailyData = new ObservableCollection<DailyWeather>();
      

        public ObservableCollection<DailyWeather> DailyData
        {
            get { return _dailyData; }
            set { _dailyData = value; OnPropertyChanged(nameof(DailyData)); }
        }

        #endregion

        #region Commands
        public ICommand SearchCityCommand { get; set; }
        public ICommand SettingsMenuCommand { get; set; }
        #endregion

    }
}
