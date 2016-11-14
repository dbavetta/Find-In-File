using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using FindInFile.Models;
using FindInFile.Wpf.Utilities;
using FindInFile.Wpf.ViewModels.Commands;
using GalaSoft.MvvmLight.Messaging;

namespace FindInFile.Wpf.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private const string TAB_HEADER = "Text Explorer";
        private ObservableCollection<TabObject<FindTextViewModel>> m_ViewModelCollection;
        private ICommand m_SettingsClicked;

        public ObservableCollection<TabObject<FindTextViewModel>> ViewModelCollection {
            get { return m_ViewModelCollection; }
            set { m_ViewModelCollection = value;  NotifyPropertyChanged("ViewModelCollection"); }
        }

        public ICommand SettingsClicked
        {
            get { return m_SettingsClicked; }
            set { m_SettingsClicked = value; }
        }

        public MainWindowViewModel()
        {
            ViewModelCollection = TabManager<FindTextViewModel>.Instance.ViewModelCollection;

            Messenger.Default.Register<PropertyChangedMessage<string>>(this, (e) => {
                NotifyPropertyChanged("ViewModelCollection");
            });

            SettingsClicked = new OpenSettingsCommand();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
