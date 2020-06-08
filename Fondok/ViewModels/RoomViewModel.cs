
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
using Fondok.Views;
using System.Windows.Controls;

namespace Fondok.ViewModels
{
    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // RoomViewModel Class
    class RoomViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        bool updating = false;
       
        //Constructor Null FirstTime
        public RoomViewModel() : this(null) {
            //MessageBox.Show("I'm Here rooms");
        }
        // Constructor With Param Of The Model
        public RoomViewModel(Room Room)
        {
           // MessageBox.Show("I'm Here rooms");
            // Add Room To Edit
            EditRoom = Room;

            //Validate Property
            IsValidProperty = false;

            //Make Properties With Fields Values
            RoomNumber = EditRoom.RoomNumber;
            RoomFloor = EditRoom.RoomFloor;
            RoomType = EditRoom.RoomType;
            RoomCapacity = EditRoom.RoomCapacity;
            RoomStatus = EditRoom.RoomStatus;
            RoomPrice = EditRoom.RoomPrice;

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

        // RoomNumber Property
        private int _RoomNumber;
        public int RoomNumber
        {
            get
            {
                return _RoomNumber;
            }
            set
            {
                if (_RoomNumber != value)
                {
                    _RoomNumber = value;
                    EditRoom.RoomNumber = _RoomNumber;
                    NotifyPropertyChanged("RoomNumber");
                }
            }
        }

        // RoomFloor Property
        private int _RoomFloor;
        public int RoomFloor
        {
            get
            {
                return _RoomFloor;
            }
            set
            {
                if (_RoomFloor != value)
                {
                    _RoomFloor = value;

                    EditRoom.RoomFloor = _RoomFloor;

                    NotifyPropertyChanged("RoomFloor");

                }
            }
        }

        // RoomType Property
        private string _RoomType;
        public string RoomType
        {
            get
            {
                return _RoomType;
            }
            set
            {
                if (_RoomType != value)
                {
                    _RoomType = value;

                    EditRoom.RoomType = _RoomType;

                    NotifyPropertyChanged("RoomType");
                }
            }
        }

        // RoomCapacity Property
        private int _RoomCapacity;
        public int RoomCapacity
        {
            get
            {
                return _RoomCapacity;
            }
            set
            {
                if (_RoomCapacity != value)
                {
                    _RoomCapacity = value;

                    EditRoom.RoomCapacity = _RoomCapacity;

                    NotifyPropertyChanged("RoomCapacity");

                }
            }
        }

        // RoomStatus Property
        private string _RoomStatus;
        public string RoomStatus
        {
            get
            {
                return _RoomStatus;
            }
            set
            {
                if (_RoomStatus != value)
                {
                    _RoomStatus = value;

                    EditRoom.RoomStatus = _RoomStatus;

                    NotifyPropertyChanged("RoomStatus");
                }
            }
        }

        // RoomPrice Property
        private double _RoomPrice;
        public double RoomPrice
        {
            get
            {
                return _RoomPrice;
            }
            set
            {
                if (_RoomPrice != value)
                {
                    _RoomPrice = value;

                    EditRoom.RoomPrice = _RoomPrice;

                    NotifyPropertyChanged("RoomPrice");
                }
            }
        }
        public bool Nn(int n)
        {

            var context = new DatabaseContext();
                      
            var Rm = (from s in context.Rooms
                      where (s.RoomNumber == RoomNumber)
                      select s.RoomNumber).ToArray();

            if (Rm.Contains(RoomNumber) == true)
            {
                return true;
            }
            else
            {
                return false;
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
                    case "RoomNumber":
                        if (RoomNumber <= 0 || RoomNumber > 9999) return FillRequired;
                        if(!updating)
                        if (Nn(RoomNumber)) return "Room Number testing allready exist!";

                        break;
                    case "RoomFloor":
                        if (RoomFloor <= 0 || RoomFloor > 99) return FillRequired;
                        break;
                    case "RoomCapacity":
                        if (RoomCapacity <= 0 || RoomCapacity > 11) return FillRequired;
                        break;
                    case "RoomPrice":
                        if (RoomPrice <= 0 || RoomPrice > 999999) return FillRequired;
                        break;

                }
                return string.Empty;
            }
        }

        // Edit Room Property
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

        // RoomWindow Run() Method
        public bool Run()
        {
            RoomWindow window = new RoomWindow();

            window.DataContext = this;

            if (window.ShowDialog() == true) { return true; }
            return false;
        }
        public bool Run(String update)
        {
            this.updating = true;
            RoomWindow window = new RoomWindow();
            window.DataContext = this;
            window.RoomNumberField.IsEnabled = false;
            if (window.ShowDialog() == true) { return true; }
            return false;
        }
        // MVVM NotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // RoomDataInteraction Class Create, Read, Update, Delete
    class RoomDataInteraction
    {
        // Loading Data From DB 
        DatabaseContext db = new DatabaseContext();

        // RoomDataInteraction Constructor
        public RoomDataInteraction(DatabaseContext _db)
        {
            db = _db;
            db.Rooms.Load();
            
        }
        // Insert Data From To BindingList
        public System.ComponentModel.BindingList<Room> GetAllRooms()
        {
            return db.Rooms.Local.ToBindingList();
        }

        // Adding Method
        public void AddRoom(Room Room)
        {
            db.Rooms.Add(Room);
            db.SaveChanges();


        }

        // Get Room Method
        public Room GetRoom(int id)
        {
            return db.Rooms.Where(get => get.RoomID.Equals(id)).First();
        }

        // Update Room Method FirstTime
        public void UpdateRoom(
            int RoomID,
            int RoomNumber,
            int RoomFloor,
            string RoomType,
            int RoomCapacity,
            string RoomStatus,
            double RoomPrice
            )
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
        // Update RoomStatus (getReserved) Amine Modification
        public void UpdateRoomStatus(
        int RoomNumber,
        string RoomStatus  )
        {

            Room Room = GetRoom(RoomNumber);

            Room.RoomStatus = RoomStatus;

            db.SaveChanges();
            RoomView rv = new RoomView();
            rv.RoomsGrid.Items.Refresh();
            RoomBox rb = new RoomBox();
            rb.UpdateRoom();
            
        }


        // Update Room Method After Insert
        public void UpdateRoom(Room update)
        {
            UpdateRoom(
                update.RoomID,
                update.RoomNumber,
                update.RoomFloor,
                update.RoomType,
                update.RoomCapacity,
                update.RoomStatus,
                update.RoomPrice
                );


        }


        // Delete Room Method
        public void DeleteRoom(int id)
        {
            db.Rooms.Remove(GetRoom(id));
            db.SaveChanges();


        }
    }


    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // RoomBox Class
    class RoomBox : INotifyPropertyChanged
    {
        private RoomDataInteraction box;
        private DatabaseContext db;
        private BindingList<Room> _Rooms;

        // Rooms BindingList Property
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

        // SelectedRoom Property
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

        // RoomBox Constructor
        public RoomBox()
        {
            db = new DatabaseContext();
            box = new RoomDataInteraction(db);
            Rooms = box.GetAllRooms();
            deleteCommand = new DelegateCommand(DeleteRoom);
            updateCommand = new DelegateCommand(UpdateRoom);
            createCommand = new DelegateCommand(CreateRoom);
        }

        // Check if Room Selected?
        public bool IsSelected()
        {
            return SelectedRoom != null;
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

        // Delete the Selected Room Method & Refresh Rooms Binding :)
        public void DeleteRoom()
        {
            if (!IsSelected())
            {
                return;
            }
            box.DeleteRoom(SelectedRoom.RoomID);
            Rooms.ResetBindings();
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

        // Update the Selected Room Method & Refresh Rooms Binding :)
        public void UpdateRoom()
        {
            // Check If Selected?
            if (!IsSelected())
            {
                return;
            }

            // Create View Model With Selected Room To Edit
            RoomViewModel vm = new RoomViewModel(SelectedRoom);
            
            // Run The Room Window And Add Selected Room To Edit & Refresh Binding
            if (vm.Run("Update"))
            {   
                box.UpdateRoom(SelectedRoom);
                Rooms.ResetBindings();
                
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

        //  Create Room Method & Refresh Rooms Binding :)
        public void CreateRoom()
        {
            Room create = new Room();

            RoomViewModel vm = new RoomViewModel(create);

            // Run The Room Window To Create Room & Refresh Binding
            if (vm.Run())
            {
                box.AddRoom(create);

                Rooms.ResetBindings();
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