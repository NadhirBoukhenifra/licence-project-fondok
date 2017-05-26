using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace Fondok.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "Hotel Managment System - ISIL 2016/2017." + Globals.userNamePlus;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _welcomeMsg = String.Format("Welcome: {0}" , Globals.userNamePlus);
        public string WelomeMsg
        {
            get { return _welcomeMsg; }
            set { SetProperty(ref _welcomeMsg, value); }

        }
        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
        }
    }
}
