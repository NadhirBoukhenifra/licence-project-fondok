using Fondok.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fondok.Views;
using Fondok.Context;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using Fondok.Commands;

namespace Fondok.ViewModels
{
    class ServiceViewModel : INotifyPropertyChanged
    {
        public ServiceViewModel() : this(null) { }
        public ServiceViewModel(Service service)
        {
            EditService = service;
        }
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
            return db.Services.Where(b => b.ID.Equals(id)).First();
        }
        public void UpdateService(int id, string title, string responsible, int duration, double price)
        {
            Service service = GetService(id);
            service.Title = title;
            service.Responsible = responsible;
            service.Duration = duration;
            service.Price = price;

            db.SaveChanges();
        }
        public void UpdateService(Service b)
        {
            UpdateService(b.ID, b.Title, b.Responsible, b.Duration, b.Price);
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
            rep.DeleteService(SelectedService.ID);
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
            if (bwvm.Run() && bk.Duration > 0 && bk.Price > 0)
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