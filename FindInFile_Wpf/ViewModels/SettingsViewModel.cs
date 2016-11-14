using System.Configuration;

namespace FindInFile.Wpf.ViewModels
{
    public class SettingsViewModel
    {
        public bool DisplayRelativeFilePaths
        {
            get
            {
                bool result; bool.TryParse(ConfigurationManager.AppSettings.Get("DisplayRelativeFilePaths"), out result);
                return result;
            }
            set
            {
                ConfigurationManager.AppSettings.Set("DisplayRelativeFilePaths", value.ToString());
                //ConfigurationManager.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("userSettings");
            }
        }

        public SettingsViewModel()
        {

        }
    }
}
