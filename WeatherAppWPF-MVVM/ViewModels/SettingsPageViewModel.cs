using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WeatherAppWPF_MVVM.ViewModels.Base;

namespace WeatherAppWPF_MVVM.ViewModels
{
    public class SettingsPageViewModel
    {
        Page mPage;
        Window mWin;
        public SettingsPageViewModel(Page page, Window win)
        {
            mWin = win;
            mPage = page;
            Units = new ObservableCollection<string> { "Celsius", "Fahrenheit" };
            AvailableLanguages = new ObservableCollection<LanguageDataModel>();
            SaveSettingsButton = new RelayCommand(() => {
                StreamWriter saveWriter = new StreamWriter("Settings/settings.json");

                if (SelectedLanguage == null)
                    SelectedLanguage = new LanguageDataModel();

                SettingsDataModel settingsToWrite = new SettingsDataModel(SelectedLanguage, HomeLocation,SelectedUnit);
                string jsonText = JsonConvert.SerializeObject(settingsToWrite, Formatting.Indented);
                saveWriter.Write(jsonText);
                saveWriter.Dispose();

                mWin.Close();
                
            });

            CancelSettingsButton = new RelayCommand(() => mWin.Close());

            LoadPage();
        }

        private void LoadPage()
        {
            #region GetAvailableLanguages
            string saveDir = Directory.GetCurrentDirectory();
            bool ErrorsFound = false;

            if (Directory.GetFiles(saveDir + "/Languages").Length > 1)
            {
                foreach (var file in Directory.GetFiles(saveDir + "/Languages", "*.lang"))
                {

                    StreamReader langReader = new StreamReader(file);
                    string rawObj = langReader.ReadToEnd();
                    try
                    {
                        LanguageDataModel tempObj = JsonConvert.DeserializeObject<LanguageDataModel>(rawObj);
                        
                        if (tempObj != null)
                            AvailableLanguages.Add(tempObj);
                       // MessageBox.Show(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        ErrorsFound = true;

                    }

                }
                if (ErrorsFound)
                {
                    MessageBox.Show("Errors Found");
                }
              
            }
            else
            {
                SelectedLanguage = new LanguageDataModel();
            }
            #endregion

            #region LoadSavedSettings
            if (File.Exists("Settings/settings.json"))
            {
               
                StreamReader settingsReader = new StreamReader("Settings/settings.json");
                try
                {
                    SettingsDataModel serializedData = JsonConvert.DeserializeObject<SettingsDataModel>(settingsReader.ReadToEnd());
                   // MessageBox.Show("loaded");
                    SelectedLanguage =  AvailableLanguages.Single(lang => lang.LanguageName == serializedData.SelectedLanguage.LanguageName);
                    if (SelectedLanguage == null)
                        SelectedLanguage = new LanguageDataModel();


                    SelectedLanguageIndex = AvailableLanguages.IndexOf(SelectedLanguage);
                    HomeLocation = serializedData.HomeLocation;
                    SelectedUnitIndex = Units.IndexOf(serializedData.Unit);
                }catch(Exception)
                {
                    SelectedLanguage = new LanguageDataModel();
                }

                settingsReader.Dispose();

            }
          

            #endregion

        }




        #region Properties
        public LanguageDataModel SelectedLanguage { get; set; }
        public int SelectedLanguageIndex { get; set; }
        public string SelectedUnit { get; set; }
        public int SelectedUnitIndex { get; set; }

        public ObservableCollection<LanguageDataModel> AvailableLanguages { get; set; }
        public ObservableCollection<string> Units { get; set; }
        public string HomeLocation { get; set; }
        #endregion

        #region Commands
        public ICommand SaveSettingsButton { get; set; }
        public ICommand CancelSettingsButton { get; set; }
        #endregion

    }
}
