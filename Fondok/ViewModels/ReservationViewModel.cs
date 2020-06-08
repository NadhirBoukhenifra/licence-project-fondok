
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

namespace Fondok.ViewModels
{
    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // ReservationViewModel Class
    class ReservationViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        //Constructor Null FirstTime
        public ReservationViewModel() : this(null) { }
        // Constructor With Param Of The Model
        public ReservationViewModel(Reservation Reservation)
        {
            // Add Reservation To Edit
            EditReservation = Reservation;

            //Validate Property
            IsValidProperty = false;

            //Make Properties With Fields Values
            CheckInDate = EditReservation.CheckInDate.Date;
            CheckOutDate = EditReservation.CheckOutDate.Date;
            ReservationStatus = EditReservation.ReservationStatus;
            ReservedBy = EditReservation.ReservedBy;
            ReservedFor = EditReservation.ReservedFor;
            RoomNumber = EditReservation.RoomNumber;
            ReservationForm = EditReservation.ReservationForm;

            // Reservation Check In Get 01/01/0001 First Time?? 
            if (CheckInDate == DateTime.MinValue)
            {
                CheckInDate = DateTime.Now;
            }
            // Reservation Check Out Get 01/01/0001 First Time??
            if (CheckOutDate == DateTime.MinValue)
            {
                CheckOutDate = DateTime.Now.AddDays(1);
            }
            //var context = new DatabaseContext();

            //var ReservedBySource = (from s in context.Employees select s.EmployeeUserName).ToArray();

            //ReservedByField.ItemsSource = ReservedBySource;

            //TotalPrice = "15000";
        }

        // CheckInDate Property
        private string _TotalPrice;
        public string TotalPrice
        {
            get
            {
                return _TotalPrice;
            }
            set
            {
                if (_TotalPrice != value)
                {
                    _TotalPrice = value;
                    //EditReservation._TotalPrice = _TotalPrice;
                    NotifyPropertyChanged("TotalPrice");
                }
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

        // CheckInDate Property
        private DateTime _CheckInDate;
        public DateTime CheckInDate
        {
            get
            {
                return _CheckInDate;
            }
            set
            {
                if (_CheckInDate != value)
                {
                    _CheckInDate = value;
                    EditReservation.CheckInDate = _CheckInDate.Date;
                    NotifyPropertyChanged("CheckInDate");
                }
            }
        }

        // CheckOutDate Property
        private DateTime _CheckOutDate;
        public DateTime CheckOutDate
        {
            get
            {
                return _CheckOutDate;
            }
            set
            {
                if (_CheckOutDate != value)
                {
                    _CheckOutDate = value;

                    EditReservation.CheckOutDate = _CheckOutDate.Date;

                    NotifyPropertyChanged("CheckOutDate");

                }
            }
        }

        // ReservationDateOfBirth Property
        private string _ReservationStatus;
        public string ReservationStatus
        {
            get
            {
                return _ReservationStatus;
            }
            set
            {
                if (_ReservationStatus != value)
                {
                    _ReservationStatus = value;

                    EditReservation.ReservationStatus = _ReservationStatus;

                    NotifyPropertyChanged("ReservationStatus");
                }
            }
        }

        // ReservedBy Property
        private string _ReservedBy;
        public string ReservedBy
        {
            get
            {
                return _ReservedBy;
            }
            set
            {
                if (_ReservedBy != value)
                {
                    _ReservedBy = value;

                    EditReservation.ReservedBy = _ReservedBy;

                    NotifyPropertyChanged("ReservedBy");

                }
            }
        }

        // ReservedFor Property
        private string _ReservedFor;
        public string ReservedFor
        {
            get
            {
                return _ReservedFor;
            }
            set
            {
                if (_ReservedFor != value)
                {
                    _ReservedFor = value;

                    EditReservation.ReservedFor = _ReservedFor;

                    NotifyPropertyChanged("ReservedFor");
                }
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

                    EditReservation.RoomNumber = _RoomNumber;

                    NotifyPropertyChanged("RoomNumber");
                }
            }
        }

        // ReservationForm Property
        private string _ReservationForm;
        public string ReservationForm
        {
            get
            {
                return _ReservationForm;
            }
            set
            {
                if (_ReservationForm != value)
                {
                    _ReservationForm = value;

                    EditReservation.ReservationForm = _ReservationForm;

                    NotifyPropertyChanged("ReservationForm");
                }
            }
        }

        // TypePayment Property
        private string _TypePayment;
        public string TypePayment
        {
            get
            {
                return _TypePayment;
            }
            set
            {
                if (_TypePayment != value)
                {
                    _TypePayment = value;

                    EditReservation.TypePayment = _TypePayment;

                    NotifyPropertyChanged("TypePayment");
                }
            }
        }

        // Add Conditions & Error Messages
        public string this[string columnName]
        {
            get
            {
                string FillRequired = "Please Fill in this field";
                switch (columnName)
                {   //Amin Mod Fixed today's date to be accepted + fixed the condition
                    case "CheckInDate":
                        DateTime now = DateTime.Now.AddHours(00-DateTime.Now.Hour).AddMinutes(00 - DateTime.Now.Minute).AddSeconds(00 - DateTime.Now.Second).AddMilliseconds(0- DateTime.Now.Millisecond);
                        if (CheckInDate < now.AddHours(-1) )
                            return "Check in date must be at least" + now.ToShortDateString();
                        break;
                    case "CheckOutDate":
                        if (CheckOutDate < CheckInDate.AddDays(1))
                            return "Please enter a Date after: " + CheckInDate.AddDays(1)+" with at least one day";
                        break;
                    case "ReservationStatus":
                        if (ReservationStatus == null) return FillRequired;

                        break;
                    case "ReservedBy":
                        if (ReservedBy == null || string.IsNullOrEmpty(ReservedBy) || string.IsNullOrWhiteSpace(ReservedBy)) return FillRequired;

                        break;
                    case "ReservedFor":
                        if (ReservedFor == null || string.IsNullOrEmpty(ReservedFor) || string.IsNullOrWhiteSpace(ReservedFor)) return FillRequired;

                        break;
                    case "RoomNumber":
                        if (RoomNumber > 0) return FillRequired;

                        break;
                    case "ReservationForm":
                        if (ReservationForm == null) return FillRequired;

                        break;
                }
                return string.Empty;
            }
        }

        // Edit Reservation Property
        private Reservation _editReservation;
        public Reservation EditReservation
        {
            get
            {
                return _editReservation;
            }
            set
            {
                _editReservation = value;

                NotifyPropertyChanged("EditReservation");
            }
        }

        // ReservationWindow Run() Method
        public bool Run()
        {
            ReservationWindow window = new ReservationWindow();

            window.DataContext = this;

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
    // ReservationDataInteraction Class Create, Read, Update, Delete
    class ReservationDataInteraction
    {
        // Loading Data From DB 
        DatabaseContext db = new DatabaseContext();

        // ReservationDataInteraction Constructor
        public ReservationDataInteraction(DatabaseContext _db)
        {
            db = _db;
            db.Reservations.Load();
            db.Rooms.Load();
        }
        // Insert Data From To BindingList
        public System.ComponentModel.BindingList<Reservation> GetAllReservations()
        {
            return db.Reservations.Local.ToBindingList();
        }
        public System.ComponentModel.BindingList<Room> GetAllRooms()
        {
            return db.Rooms.Local.ToBindingList();
        }
        // Adding Method
        public void AddReservation(Reservation Reservation)
        {
            
            //string[] ReservedForFirstNameArr = Reservation.ReservedFor.Split(' ');
            //string ReservedForFirstName = ReservedForFirstNameArr[0];
            //string ReservedForLastName = ReservedForFirstNameArr[1];
            //string[] ReservedForIDN = Reservation.ReservedFor.Split('°');
            //string IDN = ReservedForIDN[1];
            ////MessageBox.Show("First Name="+ReservedForFirstName);
            ////MessageBox.Show("Last Name=" + ReservedForLastName);
            ////MessageBox.Show("IDN=" + IDN);
            //var ReservedForSource = (from s in db.Clients where s.ClientFirstName == ReservedForFirstName && s.ClientIDNumber==Int32.Parse(IDN) && s.ClientLastName==ReservedForLastName select s.ClientID).ToArray();
            //int clientid = ReservedForSource.ElementAt(0);
            //Reservation.ReservedFor = clientid;
            db.Reservations.Add(Reservation);
            RoomDataInteraction rvm = new RoomDataInteraction(db);
            FormDataInteraction fvm = new FormDataInteraction(db);
            //Room rm = new Room();
            Form Frm = new Form();
            RoomBox rb = new RoomBox();
            rb.UpdateRoom();
            rvm.UpdateRoomStatus(Reservation.RoomNumber, "Reserved");

            //rm = rvm.GetRoom(Reservation.RoomNumber);
            //rm.RoomStatus = "Reserved";
            //rvm.UpdateRoom(rm);
            //ReservationViewModel nb = new ReservationViewModel();
            //nb.TotalPrice = "999999";

            //var ReservedBySource = (from s in context.Employees select s.EmployeeUserName).ToArray();

            InvoiceDataInteraction ivm = new InvoiceDataInteraction(db);

            Invoice inv = new Invoice();
            InvoiceBox inBox = new InvoiceBox();

            var Rm = Reservation.RoomNumber;
            var RmPrice = rvm.GetRoom(Reservation.RoomNumber).RoomPrice;
          
            var Fr = Reservation.ReservationForm;
            var FrPrice = fvm.GetFormTitle(Reservation.ReservationForm).FormPrice;
           

            DateTime a = Reservation.CheckOutDate;
            DateTime b = Reservation.CheckInDate;
            TimeSpan ts = a - b;
            double days = Math.Abs(ts.Days);

            inv.InvoiceTotal = (FrPrice + RmPrice) * days ;
           

           

            inv.InvoiceDateTime = DateTime.Now;
            inv.InvoiceTypePayment = Reservation.TypePayment;
            inv.ReservationID = Reservation.ReservationID;


            db.SaveChanges();
            rb.UpdateRoom();

            ivm.AddInvoice(inv);
            InvoiceView rv = new InvoiceView();
            rv.InvoicesGrid.Items.Refresh();
            InvoiceBox rib= new InvoiceBox();
            rib.UpdateInvoice();
            ivm.UpdateInvoice(inv);
            inBox.Invoices.ResetBindings();
                 

        }

        // Get Reservation Method
        public Reservation GetReservation(int id)
        {
            return db.Reservations.Where(get => get.ReservationID.Equals(id)).First();
        }

        // Update Reservation Method FirstTime
        public void UpdateReservation(
            int ReservationID,
            DateTime CheckInDate,
            DateTime CheckOutDate,
            string ReservationStatus,
            string ReservedBy,
            string ReservedFor,
            int RoomNumber,
            string ReservationForm,
            string TypePayment
            )
        {
            Reservation Reservation = GetReservation(ReservationID);
            Reservation.CheckInDate = CheckInDate;
            Reservation.CheckOutDate = CheckOutDate;
            Reservation.ReservationStatus = ReservationStatus;
            Reservation.ReservedBy = ReservedBy;
            Reservation.ReservedFor = ReservedFor;
            Reservation.RoomNumber = RoomNumber;
            Reservation.TypePayment = TypePayment;
            db.SaveChanges();

            //Amine Modification
            //RoomDataInteraction rvm = new RoomDataInteraction(db);
            //rvm.UpdateRoomStatus(3, "Reserved");

            //db.SaveChanges();
        }

        // Update Reservation Method After Insert
        public void UpdateReservation(Reservation update)
        {
            UpdateReservation(
                update.ReservationID,
                update.CheckInDate,
                update.CheckOutDate,
                update.ReservationStatus,
                update.ReservedBy,
                update.ReservedFor,
                update.RoomNumber,
                update.ReservationForm,           
                update.TypePayment

                );
        }

        // Delete Reservation Method
        public void DeleteReservation(int id)
        {
            Reservation Reservation = GetReservation(id);
            RoomDataInteraction rdi = new RoomDataInteraction(db);
            RoomBox rb = new RoomBox();
            rb.UpdateRoom();
            rdi.UpdateRoomStatus(Reservation.RoomNumber, "Not Reserved");
            db.Reservations.Remove(GetReservation(id));
            db.SaveChanges();

        }
    }


    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // ReservationBox Class
    class ReservationBox : INotifyPropertyChanged
    {
        private ReservationDataInteraction box;

        private DatabaseContext db;
        private BindingList<Reservation> _Reservations;

        private BindingList<Room> _Rooms;

        // Reservations BindingList Property
        public BindingList<Reservation> Reservations
        {
            get
            {
                return _Reservations;
            }
            set
            {
                _Reservations = value;
                NotifyPropertyChanged("Reservations");
            }
        }

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

        // SelectedReservation Property
        private Reservation _selectedReservation;
        public Reservation SelectedReservation
        {
            get
            {
                return _selectedReservation;
            }
            set
            {
                _selectedReservation = value;
                NotifyPropertyChanged("SelectedReservation");
            }
        }

        // ReservationBox Constructor
        public ReservationBox()
        {
            db = new DatabaseContext();
            box = new ReservationDataInteraction(db);

            Reservations = box.GetAllReservations();
            Rooms = box.GetAllRooms();

            deleteCommand = new DelegateCommand(DeleteReservation);
            updateCommand = new DelegateCommand(UpdateReservation);
            createCommand = new DelegateCommand(CreateReservation);
        }

        // Check if Reservation Selected?
        public bool IsSelected()
        {
            return SelectedReservation != null;
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

        // Delete the Selected Reservation Method & Refresh Reservations Binding :)
        public void DeleteReservation()
        {
            if (!IsSelected())
            {
                return;
            }
            box.DeleteReservation(SelectedReservation.ReservationID);
            Reservations.ResetBindings();

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

        // Update the Selected Reservation Method & Refresh Reservations Binding :)
        public void UpdateReservation()
        {
            // Check If Selected?
            if (!IsSelected())
            {
                return;
            }

            // Create View Model With Selected Reservation To Edit
            ReservationViewModel vm = new ReservationViewModel(SelectedReservation);

            // Run The Reservation Window And Add Selected Reservation To Edit & Refresh Binding
            if (vm.Run())
            {
                box.UpdateReservation(SelectedReservation);
                Reservations.ResetBindings();
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

        //  Create Reservation Method & Refresh Reservations Binding :)
        public void CreateReservation()
        {
            Reservation create = new Reservation();

            ReservationViewModel vm = new ReservationViewModel(create);

            // Run The Reservation Window To Create Reservation & Refresh Binding
            if (vm.Run())
            {
                box.AddReservation(create);
               

                Reservations.ResetBindings();
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