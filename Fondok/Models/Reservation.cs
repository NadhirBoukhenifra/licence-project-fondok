using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace Fondok.Models
{
    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------

    // Reservations Table
    [Table(Name = "Reservations")]

    // Reservation Class With Table Columns & Types
    public class Reservation
    {
        [Column(Name = "ReservationID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ReservationID { get; set; }

        [Column(Name = "CheckInDate", DbType = "DATE")]
        public DateTime CheckInDate { get; set; }

        [Column(Name = "CheckOutDate", DbType = "DATE")]
        public DateTime CheckOutDate { get; set; }

        [Column(Name = "ReservationStatus", DbType = "VARCHAR")]
        public string ReservationStatus { get; set; }

        [Column(Name = "ReservedBy", DbType = "VARCHAR")]
        public string ReservedBy { get; set; }

        [Column(Name = "ReservedFor", DbType = "VARCHAR")]
        public string ReservedFor { get; set; }

        [Column(Name = "RoomNumber", DbType = "INTEGER")]
        public int RoomNumber { get; set; }

        [Column(Name = "ReservationForm", DbType = "VARCHAR")]
        public string ReservationForm { get; set; }

        [Column(Name = "TypePayment", DbType = "VARCHAR")]
        public string TypePayment { get; set; }


    }
}
