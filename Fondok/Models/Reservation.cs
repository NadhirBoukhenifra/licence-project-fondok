using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace Fondok.Models
{

    [Table(Name = "Reservations")]
    public class Reservation
    {
        [Column(Name = "ReservationID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ReservationID { get; set; }

        [Column(Name = "ArrivalDate", DbType = "DATE")]
        public DateTime ArrivalDate { get; set; }

        [Column(Name = "DepartureDate", DbType = "DATE")]
        public DateTime DepartureDate { get; set; }

        [Column(Name = "ReservationStatus", DbType = "VARCHAR")]
        public string ReservationStatus { get; set; }

        [Column(Name = "ReservedBy", DbType = "VARCHAR")]
        public string ReservedBy { get; set; }

        [Column(Name = "ClientID", DbType = "INTEGER")]
        public int ClientID { get; set; }

        [Column(Name = "RoomNumber", DbType = "INTEGER")]
        public int RoomNumber { get; set; }

        [Column(Name = "ReservationForm", DbType = "VARCHAR")]
        public string ReservationForm { get; set; }

    }
}
