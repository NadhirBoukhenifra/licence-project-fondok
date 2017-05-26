using Microsoft.Practices.Unity;
using Prism.Unity;
using Fondok.Views;
using System.Windows;
using Prism.Modularity;
using Fondok;

namespace Fondok
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //return Container.Resolve<MainWindow>();
           
                return Container.Resolve<MainWindow>();
            
        }


        protected override void InitializeShell()
        {

            Application.Current.MainWindow.Show();
            
            
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ModuleInitializer));
            
        }
    }
}
