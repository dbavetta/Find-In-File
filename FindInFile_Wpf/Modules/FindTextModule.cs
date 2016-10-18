using FindInFile.Wpf.ViewModels;
using FindInFile.Wpf.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace FindInFile.Wpf.Modules
{
    public class FindTextModule : IModule
    {
        private IUnityContainer m_container;
        private IRegionManager m_RegionManager;

        public FindTextModule(IUnityContainer container, IRegionManager regionManager)
        {
            m_container = container;
            m_RegionManager = regionManager;
        }

        public void Initialize()
        {
            m_container.RegisterType<FindTextViewModel>();
            //IRegion region = m_RegionManager.Regions[RegionNames.MainRegion];
            //var view = m_container.Resolve<FindTextView>();
            //region.Add(view, typeof(FindTextView).FullName);
            //region.Activate(view);

            //m_RegionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(FindTextView));

            //var v = m_container.Resolve<FindTextView>();
            //m_RegionManager.Regions[RegionNames.MainRegion].Add(v);
        }
    }
}
