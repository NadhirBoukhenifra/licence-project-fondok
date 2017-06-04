
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
    class ReservationViewModel : INotifyPropertyChanged
    {

        public ReservationViewModel() : this(null) { }
        public ReservationViewModel(Reservation Reservation)
        {
            EditReservation = Reservation;
        }
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
        public bool Run()
        {
            ReservationWindow sw = new ReservationWindow();
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





    class ReservationRepository
    {

        DatabaseContext db = new DatabaseContext();
        public ReservationRepository(DatabaseContext _db)
        {
            db = _db;
            db.Reservations.Load();
        }
        public System.ComponentModel.BindingList<Reservation> GetAllReservations()
        {
            return db.Reservations.Local.ToBindingList();
        }
        public void AddReservation(Reservation Reservation)
        {
            db.Reservations.Add(Reservation);
            db.SaveChanges();
        }
        public Reservation GetReservation(int id)
        {
            return db.Reservations.Where(b => b.ReservationID.Equals(id)).First();
        }
        public void UpdateReservation(int ReservationID, string ReservationFrom, string ReservationTo, string ReservationStatus
            , string ReservationBy, string ReservationFor, string ReservationIn, string ReservationService)
        {
            Reservation Reservation = GetReservation(ReservationID);
            Reservation.ReservationFrom = ReservationFrom;
            Reservation.ReservationTo = ReservationTo;
            Reservation.ReservationStatus = ReservationStatus;
            Reservation.ReservationBy = ReservationBy;
            Reservation.ReservationFor = ReservationFor;
            Reservation.ReservationIn = ReservationIn;
            Reservation.ReservationService = ReservationService;

            db.SaveChanges();
        }
        public void UpdateReservation(Reservation b)
        {
            UpdateReservation(b.ReservationID, b.ReservationFrom, b.ReservationTo, b.ReservationStatus
                , b.ReservationBy, b.ReservationFor, b.ReservationIn, b.ReservationService);
        }
        public void DeleteReservation(int id)
        {
            db.Reservations.Remove(GetReservation(id));
            db.SaveChanges();
        }
    }













    class ReservationLibraryViewModel : INotifyPropertyChanged
    {
        private ReservationRepository rep;
        private DatabaseContext db;
        private BindingList<Reservation> _Reservations;
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
        public ReservationLibraryViewModel()
        {
            db = new DatabaseContext();
            rep = new ReservationRepository(db);
            Reservations = rep.GetAllReservations();
            deleteCommand = new DelegateCommand(DeleteReservation);
            updateCommand = new DelegateCommand(UpdateReservation);
            createCommand = new DelegateCommand(CreateReservation);
        }
        public bool IsSelected()
        {
            return SelectedReservation != null;
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }
        public void DeleteReservation()
        {
            if (!IsSelected())
            {
                return;
            }
            rep.DeleteReservation(SelectedReservation.ReservationID);
        }
        private DelegateCommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }
        public void UpdateReservation()
        {
            if (!IsSelected())
            {
                return;
            }
            ReservationViewModel bwvm = new ReservationViewModel(SelectedReservation);
            if (bwvm.Run())
            {
                rep.UpdateReservation(SelectedReservation);
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
        public void CreateReservation()
        {
            Reservation bk = new Reservation();
            ReservationViewModel bwvm = new ReservationViewModel(bk);
            if (bwvm.Run())
            {
                rep.AddReservation(bk);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}