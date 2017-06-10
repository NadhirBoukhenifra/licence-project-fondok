
using Fondok.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fondok.Views;
using Fondok.Views.Windows;
using Fondok.Context;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using Fondok.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Fondok.ViewModels
{

    class ServiceViewModel : INotifyPropertyChanged
    {
        private string _title = "Services";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                Title = _title;

            }
        }

        public ServiceViewModel() : this(null) { }
        public ServiceViewModel(Service service)
        {
            EditService = service;

            //using (var context = new DatabaseContext())
            //{
            //    //List<Employee> EmployeesList = (from s in context.Employees select s).ToList<Employee>();
            //    List<Employee> EmployeesList = (from s in context.Employees select s).ToList<Employee>();

            //    //ResList = EmployeesList[0].EmployeeLastName.ToList();
            //    //for (int i = 0; i < EmployeesList.Count(); i++)
            //    //{
            //    //    ResList = EmployeesList[i].EmployeeUserName;
            //    //}
            //    //ResList = "Hekk" + EmployeesList[0].EmployeeJob;
            //    //ResList = EmployeesList[0].EmployeeLastName;
            //    //REmployeesList = new List<Employee> { };
            //    //foreach (var s in EmployeesList)
            //    //{
            //    //    REmployeesList.Add(EmployeesList[i].ToString());
            //    //}
            //    MessageBox.Show(EmployeesList.Count().ToString() + EmployeesList[0].EmployeeUserName + EmployeesList[1].EmployeeUserName);
                

            //}




        }

        //private string _REmployeesList;
        //public string REmployeesList
        //{
        //    get
        //    {
        //        return REmployeesList;
        //    }
        //    set
        //    {
        //        _REmployeesList = value;
        //        NotifyPropertyChanged("REmployeesList");
        //    }
        //}
        private Service _editService;
        public Service EditService
        {
            get
            {
                return _editService;
            }
            set
            {
                _editService = value;
                NotifyPropertyChanged("EditService");
            }
        }
        public bool Run()
        {
            ServiceWindow sw = new ServiceWindow();
            sw.DataContext = this;
            if (sw.ShowDialog() == true)
            {
                return true;
            }
            return false;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }





    class ServiceRepository
    {

        DatabaseContext db = new DatabaseContext();
        public ServiceRepository(DatabaseContext _db)
        {
            db = _db;
            db.Services.Load();
        }
        public System.ComponentModel.BindingList<Service> GetAllServices()
        {
            return db.Services.Local.ToBindingList();
        }
        public void AddService(Service service)
        {
            db.Services.Add(service);
            db.SaveChanges();
        }
        public Service GetService(int id)
        {
            return db.Services.Where(b => b.ServiceID.Equals(id)).First();
        }
        public void UpdateService(int serviceID, string serviceTitle, string serviceResponsible, int servicePrice)
        {
            Service service = GetService(serviceID);
            service.ServiceTitle = serviceTitle;
            service.ServiceResponsible = serviceResponsible;
            service.ServicePrice = servicePrice;

            db.SaveChanges();
        }
        public void UpdateService(Service b)
        {
            UpdateService(b.ServiceID, b.ServiceTitle, b.ServiceResponsible, b.ServicePrice);
        }
        public void DeleteService(int id)
        {
            db.Services.Remove(GetService(id));
            db.SaveChanges();
        }
    }













    class ServiceLibraryViewModel : INotifyPropertyChanged
    {
        private ServiceRepository rep;
        private DatabaseContext db;
        private BindingList<Service> _services;
        public BindingList<Service> Services
        {
            get
            {
                return _services;
            }
            set
            {
                _services = value;
                NotifyPropertyChanged("Services");
            }
        }
        private Service _selectedService;
        public Service SelectedService
        {
            get
            {
                return _selectedService;
            }
            set
            {
                _selectedService = value;
                NotifyPropertyChanged("SelectedService");
            }
        }
        public ServiceLibraryViewModel()
        {
            db = new DatabaseContext();
            rep = new ServiceRepository(db);
            Services = rep.GetAllServices();
            deleteCommand = new DelegateCommand(DeleteService);
            updateCommand = new DelegateCommand(UpdateService);
            createCommand = new DelegateCommand(CreateService);
        }
        public bool IsSelected()
        {
            return SelectedService != null;
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }
        public void DeleteService()
        {
            if (!IsSelected())
            {
                return;
            }
            rep.DeleteService(SelectedService.ServiceID);
        }
        private DelegateCommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }
        public void UpdateService()
        {
            if (!IsSelected())
            {
                return;
            }
            ServiceViewModel bwvm = new ServiceViewModel(SelectedService);
            if (bwvm.Run())
            {
                rep.UpdateService(SelectedService);
            }
        }
        private DelegateCommand createCommand;
        public ICommand CreateCommand
        {
            get
            {
                return createCommand;
            }
        }
        public void CreateService()
        {
            Service bk = new Service();
            ServiceViewModel bwvm = new ServiceViewModel(bk);
            if (bwvm.Run() && bk.ServiceTitle != "" && bk.ServiceResponsible != "" && bk.ServicePrice > 0)
            {
                rep.AddService(bk);
            }
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}