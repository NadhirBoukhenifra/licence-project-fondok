
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
using System;

namespace Fondok.ViewModels
{
    class ClientViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private bool _IsValidProperty;
        public bool IsValidProperty
        {
            get
            {
                return _IsValidProperty;
            }
            set
            {
                if (_IsValidProperty != value)
                {
                    _IsValidProperty = value;
                    NotifyPropertyChanged("IsValidProperty");
                }
            }
        }
        public ClientViewModel() : this(null) { }
        public ClientViewModel(Client Client)
        {
            EditClient = Client;

            nFirstName = EditClient.ClientFirstName;
            nLastName = EditClient.ClientLastName;
            nClientDateOfBirth = EditClient.ClientDateOfBirth;
            //nClientDateOfBirth = EditClient.ClientDateOfBirth;
            IsValidProperty = false;

        }
        public string Error
        {
            get
            {
                return string.Empty;
            }
        }
        private string _nFirstName;
        public string nFirstName
        {
            get
            {
                return _nFirstName;
            }
            set
            {
                if (_nFirstName != value)
                {
                _nFirstName = value;
                    EditClient.ClientFirstName = _nFirstName;
                    NotifyPropertyChanged("_nFirstName");
                }
            }
        }

        private string _nLastName;
        public string nLastName
        {
            get
            {
                return _nLastName;
            }
            set
            {
                if (_nLastName != value)
                {
                     _nLastName = value;

                    EditClient.ClientLastName = _nLastName;

                    NotifyPropertyChanged("_nLastName");
                    
                }
            }
        }

        private DateTime _nClientDateOfBirth;
        public DateTime nClientDateOfBirth
        {
            get
            {
                return _nClientDateOfBirth;
            }
            set
            {
                if (_nClientDateOfBirth != value)
                {
                    _nClientDateOfBirth = value;

                    EditClient.ClientDateOfBirth = _nClientDateOfBirth;

                    NotifyPropertyChanged("_nClientDateOfBirth");

                }
            }
        }
        public string this[string columnName]
        {
            get
            {
                string FillRequired = "Please Fill The Field";
                switch (columnName)
                {
                    case "nFirstName":
                        if (nFirstName == null || nFirstName == "") return FillRequired;

                        break;
                    case "nLastName":
                        if (nLastName == null || nLastName == "") return FillRequired;

                        break;
                    case "nClientDateOfBirth":
                        if (nClientDateOfBirth > DateTime.Now.AddYears(-10)  || nClientDateOfBirth < DateTime.Now.AddYears(-100))

                            return "Date Range: " + DateTime.Now.AddYears(-10) +
                                " & " + DateTime.Now.AddYears(-100);
                        break;
                }
                return string.Empty;
            }
        }
        private Client _editClient;
        public Client EditClient
        {
            get
            {
                return _editClient;
            }
            set
            {
                
               _editClient = value;
                
                NotifyPropertyChanged("EditClient");

            }
        }
        public bool Run()
        {
            ClientWindow sw = new ClientWindow();
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





    class ClientRepository
    {

        DatabaseContext db = new DatabaseContext();
        public ClientRepository(DatabaseContext _db)
        {
            db = _db;
            db.Clients.Load();
        }
        public System.ComponentModel.BindingList<Client> GetAllClients()
        {
            return db.Clients.Local.ToBindingList();
        }
        public void AddClient(Client Client)
        {
            db.Clients.Add(Client);

            db.SaveChanges();

            
        }
        public Client GetClient(int id)
        {
            return db.Clients.Where(b => b.ClientID.Equals(id)).First();
        }
        public void UpdateClient(int ClientID, string ClientFirstName, string ClientLastName, DateTime ClientDateOfBirth)
        {
            Client Client = GetClient(ClientID);
            Client.ClientFirstName = Client.ClientFirstName;
            Client.ClientLastName = ClientLastName;
            Client.ClientDateOfBirth = ClientDateOfBirth;
            db.SaveChanges();
        }
        public void UpdateClient(Client b)
        {
            UpdateClient(b.ClientID, b.ClientFirstName, b.ClientLastName, b.ClientDateOfBirth);
        }
        public void DeleteClient(int id)
        {
            db.Clients.Remove(GetClient(id));
            db.SaveChanges();
        }
    }













    class ClientLibraryViewModel : INotifyPropertyChanged
    {
        private ClientRepository rep;
        private DatabaseContext db;
        private BindingList<Client> _Clients;
        public BindingList<Client> Clients
        {
            get
            {
                return _Clients;
            }
            set
            {
                _Clients = value;
                NotifyPropertyChanged("Clients");
            }
        }
        private Client _selectedClient;
        public Client SelectedClient
        {
            get
            {
                return _selectedClient;
            }
            set
            {
                _selectedClient = value;
                NotifyPropertyChanged("SelectedClient");
            }
        }
        public ClientLibraryViewModel()
        {
            db = new DatabaseContext();
            rep = new ClientRepository(db);
            Clients = rep.GetAllClients();
            deleteCommand = new DelegateCommand(DeleteClient);
            updateCommand = new DelegateCommand(UpdateClient);
            createCommand = new DelegateCommand(CreateClient);
        }
        public bool IsSelected()
        {
            return SelectedClient != null;
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }
        public void DeleteClient()
        {
            if (!IsSelected())
            {
                return;
            }
            rep.DeleteClient(SelectedClient.ClientID);
            Clients.ResetBindings();
        }
        private DelegateCommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }
        public void UpdateClient()
        {
            if (!IsSelected())
            {
                return;
            }
            ClientViewModel bwvm = new ClientViewModel(SelectedClient);
            if (bwvm.Run())
            {
                rep.UpdateClient(SelectedClient);
                Clients.ResetBindings();
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
        public void CreateClient()
        {
            Client bk = new Client();
            ClientViewModel bwvm = new ClientViewModel(bk);
            if (bwvm.Run())
            {
                rep.AddClient(bk);
                Clients.ResetBindings();

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}