
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
    class RoomViewModel : INotifyPropertyChanged
    {

        public RoomViewModel() : this(null) { }
        public RoomViewModel(Room Room)
        {
            EditRoom = Room;
        }
        private Room _editRoom;
        public Room EditRoom
        {
            get
            {
                return _editRoom;
            }
            set
            {
                _editRoom = value;
                NotifyPropertyChanged("EditRoom");
            }
        }
        public bool Run()
        {
            RoomWindow sw = new RoomWindow();
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





    class RoomRepository
    {

        DatabaseContext db = new DatabaseContext();
        public RoomRepository(DatabaseContext _db)
        {
            db = _db;
            db.Rooms.Load();
        }
        public System.ComponentModel.BindingList<Room> GetAllRooms()
        {
            return db.Rooms.Local.ToBindingList();
        }
        public void AddRoom(Room Room)
        {
            db.Rooms.Add(Room);
            db.SaveChanges();
        }
        public Room GetRoom(int id)
        {
            return db.Rooms.Where(b => b.RoomID.Equals(id)).First();
        }
        public void UpdateRoom(int RoomID, string RoomNumber, string RoomFloor, string RoomType,
                                string RoomCapacity, string RoomStatus, string RoomPrice)
        {
            Room Room = GetRoom(RoomID);
            Room.RoomNumber = RoomNumber;
            Room.RoomFloor = RoomFloor;
            Room.RoomType = RoomType;
            Room.RoomCapacity = RoomCapacity;
            Room.RoomStatus = RoomStatus;
            Room.RoomPrice = RoomPrice;

            db.SaveChanges();
        }
        public void UpdateRoom(Room b)
        {
            UpdateRoom(b.RoomID, b.RoomNumber, b.RoomFloor, b.RoomType, b.RoomCapacity, b.RoomStatus, b.RoomPrice);
        }
        public void DeleteRoom(int id)
        {
            db.Rooms.Remove(GetRoom(id));
            db.SaveChanges();
        }
    }













    class RoomLibraryViewModel : INotifyPropertyChanged
    {
        private RoomRepository rep;
        private DatabaseContext db;
        private BindingList<Room> _Rooms;
        public BindingList<Room> Rooms
        {
            get
            {
                return _Rooms;
            }
            set
            {
                _Rooms = value;
                NotifyPropertyChanged("Rooms");
            }
        }
        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get
            {
                return _selectedRoom;
            }
            set
            {
                _selectedRoom = value;
                NotifyPropertyChanged("SelectedRoom");
            }
        }
        public RoomLibraryViewModel()
        {
            db = new DatabaseContext();
            rep = new RoomRepository(db);
            Rooms = rep.GetAllRooms();
            deleteCommand = new DelegateCommand(DeleteRoom);
            updateCommand = new DelegateCommand(UpdateRoom);
            createCommand = new DelegateCommand(CreateRoom);
        }
        public bool IsSelected()
        {
            return SelectedRoom != null;
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }
        public void DeleteRoom()
        {
            if (!IsSelected())
            {
                return;
            }
            rep.DeleteRoom(SelectedRoom.RoomID);
        }
        private DelegateCommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }
        public void UpdateRoom()
        {
            if (!IsSelected())
            {
                return;
            }
            RoomViewModel bwvm = new RoomViewModel(SelectedRoom);
            if (bwvm.Run())
            {
                rep.UpdateRoom(SelectedRoom);
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
        public void CreateRoom()
        {
            Room bk = new Room();
            RoomViewModel bwvm = new RoomViewModel(bk);
            if (bwvm.Run()/* && bk.Duration > 0 && bk.Price > 0*/)
            {
                rep.AddRoom(bk);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}