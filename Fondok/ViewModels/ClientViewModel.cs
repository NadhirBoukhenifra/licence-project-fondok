
using Fondok.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fondok.Views.Windows;
using Fondok.Context;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using Fondok.Commands;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Data;
using System.Globalization;

namespace Fondok.ViewModels
{
    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // ClientViewModel Class
    class ClientViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        //Constructor Null FirstTime
        public ClientViewModel() : this(null) { }
        // Constructor With Param Of The Model
        public ClientViewModel(Client Client)
        {
            // Add Client To Edit
            EditClient = Client;

            //Validate Property
            IsValidProperty = false;

            //Make Properties With Fields Values
            ClientFirstName = EditClient.ClientFirstName;
            ClientLastName = EditClient.ClientLastName;
            ClientDateOfBirth =EditClient.ClientDateOfBirth.Date;
            ClientGender = EditClient.ClientGender;
            ClientIDType = EditClient.ClientIDType;
            ClientIDNumber = EditClient.ClientIDNumber;
            ClientParent = EditClient.ClientParent;

            // ClientDateOfBirth Get 01/01/0001 First Time?? 
            if (ClientDateOfBirth == DateTime.MinValue)
            {
                ClientDateOfBirth = DateTime.Now.AddYears(-10);
            }
            
        }


        //IsValidProperty For Validation
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

        // Implementation Of IDataErrorInfo For Validation
        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        // ClientFirstName Property
        private string _ClientFirstName;
        public string ClientFirstName
        {
            get
            {
                return _ClientFirstName;
            }
            set
            {
                if (_ClientFirstName != value)
                {
                    _ClientFirstName = value;
                    EditClient.ClientFirstName = _ClientFirstName;
                    NotifyPropertyChanged("ClientFirstName");
                }
            }
        }

        // ClientLastName Property
        private string _ClientLastName;
        public string ClientLastName
        {
            get
            {
                return _ClientLastName;
            }
            set
            {
                if (_ClientLastName != value)
                {
                    _ClientLastName = value;

                    EditClient.ClientLastName = _ClientLastName;

                    NotifyPropertyChanged("ClientLastName");
                    
                }
            }
        }

        // ClientDateOfBirth Property
        private DateTime _ClientDateOfBirth;
        public DateTime ClientDateOfBirth
        {
            get
            {
                return _ClientDateOfBirth;
            }
            set
            {
                if (_ClientDateOfBirth != value)
                {
                    _ClientDateOfBirth = value;

                    EditClient.ClientDateOfBirth = _ClientDateOfBirth.Date;

                    NotifyPropertyChanged("ClientDateOfBirth");
                }
            }
        }

        // ClientGender Property
        private string _ClientGender;
        public string ClientGender
        {
            get
            {
                return _ClientGender;
            }
            set
            {
                if (_ClientGender != value)
                {
                    _ClientGender = value;

                    EditClient.ClientGender = _ClientGender;

                    NotifyPropertyChanged("ClientGender");

                }
            }
        }

        // ClientIDType Property
        private string _ClientIDType;
        public string ClientIDType
        {
            get
            {
                return _ClientIDType;
            }
            set
            {
                if (_ClientIDType != value)
                {
                    _ClientIDType = value;

                    EditClient.ClientIDType = _ClientIDType;

                    NotifyPropertyChanged("ClientIDType");
                }
            }
        }

        // ClientIDType Property
        private int _ClientIDNumber;
        public int ClientIDNumber
        {
            get
            {
                return _ClientIDNumber;
            }
            set
            {
                if (_ClientIDNumber != value)
                {
                    _ClientIDNumber = value;

                    EditClient.ClientIDNumber = _ClientIDNumber;

                    NotifyPropertyChanged("ClientIDNumber");
                }
            }
        }

        // ClientIDType Property
        private string _ClientParent;
        public string ClientParent
        {
            get
            {
                return _ClientParent;
            }
            set
            {
                if (_ClientParent != value)
                {
                    _ClientParent = value;

                    EditClient.ClientParent = _ClientParent;

                    NotifyPropertyChanged("ClientParent");
                }
            }
        }

        // Add Conditions & Error Messages
        public string this[string columnName]
        {
            get
            {
                string FillRequired = "Please Fill The Field";
                switch (columnName)
                {
                    case "ClientFirstName":
                        if (ClientFirstName == null || ClientFirstName == "") return FillRequired;

                        break;
                    case "ClientLastName":
                        if (ClientLastName == null || ClientLastName == "") return FillRequired;

                        break;
                    case "ClientDateOfBirth":
                        if (ClientDateOfBirth > DateTime.Now.AddYears(-10) || ClientDateOfBirth < DateTime.Now.AddYears(-100))
                            return "Date Range: " + DateTime.Now.AddYears(-100).Date + " & " + DateTime.Now.AddYears(-10).Date;

                        break;
                    case "ClientGender":
                        if (ClientGender == null) return FillRequired;

                        break;
                    case "ClientIDType":
                        if (ClientIDType == null) return FillRequired;

                        break;
                    case "ClientIDNumber":
                        if (string.IsNullOrWhiteSpace(ClientIDNumber.ToString()) || string.IsNullOrEmpty(ClientIDNumber.ToString()) || ClientIDNumber <= 0) return FillRequired;

                        break;
                    case "ClientParent":
                        if (ClientParent == null) return FillRequired;

                        break;
                }
                return string.Empty;
            }
        }

        // Edit Client Property
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

        // ClientWindow Run() Method
        public bool Run()
        {
            ClientWindow window = new ClientWindow();

            window.DataContext = this;

            if (window.ShowDialog() == true) { return true; } return false;
        }

        // MVVM NotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // ClientDataInteraction Class Create, Read, Update, Delete
    class ClientDataInteraction
    {
        // Loading Data From DB 
        DatabaseContext db = new DatabaseContext();

        // ClientDataInteraction Constructor
        public ClientDataInteraction(DatabaseContext _db)
        {
            db = _db;
            db.Clients.Load();
        }
        // Insert Data From To BindingList
        public System.ComponentModel.BindingList<Client> GetAllClients()
        {
            return db.Clients.Local.ToBindingList();
        }

        // Adding Method
        public void AddClient(Client Client)
        {
            db.Clients.Add(Client);
            db.SaveChanges();
        }

        // Get Client Method
        public Client GetClient(int id)
        {
            return db.Clients.Where(get => get.ClientID.Equals(id)).First();
        }

        // Update Client Method FirstTime
        public void UpdateClient(
            int ClientID,
            string ClientFirstName,
            string ClientLastName,
            DateTime ClientDateOfBirth, 
            string ClientGender,
            string ClientIDType,
            int ClientIDNumber,
            string ClientParent
            )
        {
            Client Client = GetClient(ClientID);
            Client.ClientFirstName = ClientFirstName;
            Client.ClientLastName = ClientLastName;
            Client.ClientDateOfBirth = ClientDateOfBirth;
            Client.ClientGender = ClientGender;
            Client.ClientIDType = ClientIDType;
            Client.ClientIDNumber = ClientIDNumber;
            Client.ClientParent = ClientParent;

            db.SaveChanges();
        }

        // Update Client Method After Insert
        public void UpdateClient(Client update)
        {
            UpdateClient(
                update.ClientID,
                update.ClientFirstName,
                update.ClientLastName,
                update.ClientDateOfBirth,
                update.ClientGender,
                update.ClientIDType,
                update.ClientIDNumber,
                update.ClientParent
                );
        }

        // Delete Client Method
        public void DeleteClient(int id)
        {
            db.Clients.Remove(GetClient(id));
            db.SaveChanges();
        }
    }


    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // ClientBox Class
    class ClientBox : INotifyPropertyChanged
    {
        private ClientDataInteraction box;
        private DatabaseContext db;
        private BindingList<Client> _Clients;

        // Clients BindingList Property
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

        // SelectedClient Property
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

        // ClientBox Constructor
        public ClientBox()
        {
            db = new DatabaseContext();
            box = new ClientDataInteraction(db);
            Clients = box.GetAllClients();
            deleteCommand = new DelegateCommand(DeleteClient);
            updateCommand = new DelegateCommand(UpdateClient);
            createCommand = new DelegateCommand(CreateClient);
        }
        
        // Check if Client Selected?
        public bool IsSelected()
        {
            return SelectedClient != null;
        }

        // Implementation Of DeleteCommand Property
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }

        // Delete the Selected Client Method & Refresh Clients Binding :)
        public void DeleteClient()
        {
            if (!IsSelected())
            {
                return;
            }
            box.DeleteClient(SelectedClient.ClientID);
            Clients.ResetBindings();
        }

        // Implementation Of UpdateCommand Property
        private DelegateCommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }

        // Update the Selected Client Method & Refresh Clients Binding :)
        public void UpdateClient()
        {
            // Check If Selected?
            if (!IsSelected())
            {
                return;
            }

            // Create View Model With Selected Client To Edit
            ClientViewModel vm = new ClientViewModel(SelectedClient);

            // Run The Client Window And Add Selected Client To Edit & Refresh Binding
            if (vm.Run())
            {
                box.UpdateClient(SelectedClient);
                Clients.ResetBindings();
            }
        }

        // Implementation Of CreateCommand Property
        private DelegateCommand createCommand;
        public ICommand CreateCommand
        {
            get
            {
                return createCommand;
            }
        }

        //  Create Client Method & Refresh Clients Binding :)
        public void CreateClient()
        {
            Client create = new Client();

            ClientViewModel vm = new ClientViewModel(create);

            // Run The Client Window To Create Client & Refresh Binding
            if (vm.Run())
            {
                box.AddClient(create);

                Clients.ResetBindings();
            }
        }

        // MVVM NotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}