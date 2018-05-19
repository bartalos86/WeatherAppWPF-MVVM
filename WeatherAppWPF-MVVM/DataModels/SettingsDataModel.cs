namespace WeatherAppWPF_MVVM
{
    public class SettingsDataModel
    {
        public SettingsDataModel(LanguageDataModel selectedLang, string homeLoc, string unit)
        {
            SelectedLanguage = selectedLang;
            HomeLocation = homeLoc;
            Unit = unit;
        }

        public LanguageDataModel SelectedLanguage { get; set; }
        public string HomeLocation { get; set; }
        public string Unit { get; set; }

    }
}
