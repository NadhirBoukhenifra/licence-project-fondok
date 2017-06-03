
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

namespace Fondok.ViewModels
{
    class ClientViewModel : INotifyPropertyChanged
    {

        public ClientViewModel() : this(null) { }
        public ClientViewModel(Client Client)
        {
            EditClient = Client;
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
        public void UpdateClient(int ClientID, string ClientFirstName, string ClientLastName, string ClientDateOfBirth)
        {
            Client Client = GetClient(ClientID);
            Client.ClientFirstName = ClientFirstName;
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
            if (bwvm.Run()/* && bk.Duration > 0 && bk.Price > 0*/)
            {
                rep.AddClient(bk);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}