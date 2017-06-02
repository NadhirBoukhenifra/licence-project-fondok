using Microsoft.Practices.Unity;
using Fondok.Views;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;

namespace Fondok
{
    public class ModuleInitializer : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public ModuleInitializer(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;

            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(RoomView));



        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<RoomView>();
            _container.RegisterTypeForNavigation<ServiceView>();
            _container.RegisterTypeForNavigation<BookView>();
        }
    }
}