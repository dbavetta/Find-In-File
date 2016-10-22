using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FindInFile.Models;
using FindInFile.Models.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace FindInFile.Wpf.Utilities
{
    public sealed class TabManager<ViewModel>
    {
        #region Singleton Structure
        private static readonly Lazy<TabManager<ViewModel>> m_Instance =
            new Lazy<TabManager<ViewModel>>(() => new TabManager<ViewModel>());

        private TabManager()
        {
        }

        public static TabManager<ViewModel> Instance { get { return m_Instance.Value; } }
        #endregion

        private bool m_Initialized = false;
        private const string TAB_HEADER = "Text Explorer";
        private ObservableCollection<TabObject<ViewModel>> m_ViewModelCollection;
        private Dictionary<int, Guid> m_TabTokenAssociation;
        private TabObject<ViewModel> m_LastTab;
        private TabObject<ViewModel> m_PlusTab;
        private TabObject<ViewModel> m_ActiveTab;

        public bool Initialized
        {
            get { return m_Initialized; }
        }

        public void Initialize()
        {
            BuildDefaultState();
        }

        public TabObject<ViewModel> ActiveTab
        {
            get { return m_ActiveTab; }
            set { m_ActiveTab = value; }
        }
        public ObservableCollection<TabObject<ViewModel>> ViewModelCollection
        {
            get { return m_ViewModelCollection; }
            set { m_ViewModelCollection = value; }
        }

        public void AddTab(string header = null)
        {
            var tab = CreateNewTabObject(header);
            m_ViewModelCollection.Insert(tab.Index, tab);
            m_TabTokenAssociation.Add(tab.Index, Guid.NewGuid());

            m_ActiveTab = m_LastTab = tab;

            Messenger.Default.Send(new UpdateTabControlMessage());
        }

        public void RemoveTab(TabObject<ViewModel> tab)
        {
            m_ViewModelCollection.RemoveAt(tab.Index+1);
            m_TabTokenAssociation.Remove(tab.Index);
        }

        public int TabCount()
        {
            if (m_ViewModelCollection == null || m_ViewModelCollection.Count < 1)
                return 0;
            else
                return m_ViewModelCollection.Count - 1; //-1 to exclude the '+' tab
        }

        public void SwitchToTab(TabObject<ViewModel> tab)
        {
            if (tab != m_PlusTab)
                m_ActiveTab = tab;
            else
                AddTab();
        }

        public Guid ResolveActiveTabToken()
        {
            return m_TabTokenAssociation[m_ActiveTab.Index];
        }

        private void BuildDefaultState()
        {
            m_ViewModelCollection = new ObservableCollection<TabObject<ViewModel>>();
            m_TabTokenAssociation = new Dictionary<int, Guid>();

            var baseTab = CreateNewTabObject();
            var plusTab = CreateNewTabObject("+");

            m_ViewModelCollection.Add(baseTab);
            m_ViewModelCollection.Add(plusTab);

            m_TabTokenAssociation.Add(baseTab.Index, Guid.NewGuid());

            m_ActiveTab = m_LastTab = m_ViewModelCollection.First();
            m_PlusTab = m_ViewModelCollection.Last();
            m_Initialized = true;
        }

        private TabObject<ViewModel> CreateNewTabObject(string header = null)
        {
            var type = typeof(ViewModel);
            object _viewModel = Activator.CreateInstance(type);
            ViewModel viewModel = (ViewModel)_viewModel;

            return new TabObject<ViewModel>()
            {
                Header = header != null ? header : TAB_HEADER,
                Index = TabCount(),
                Content = viewModel
            };
        }
    }
}