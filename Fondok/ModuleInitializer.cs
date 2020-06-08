using Microsoft.Practices.Unity;
using Fondok.Views;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;


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

            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ReservationView));


			

        }

        public void Initialize()
        {
            
            _container.RegisterTypeForNavigation<RoomView>();
            _container.RegisterTypeForNavigation<ClientView>();
            _container.RegisterTypeForNavigation<EmployeeView>();
            _container.RegisterTypeForNavigation<FormView>();
            _container.RegisterTypeForNavigation<ReservationView>();
            _container.RegisterTypeForNavigation<InvoiceView>();
            _container.RegisterTypeForNavigation<ReportView>();

        }
    }
}