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

        [Column(Name = "ReservationFrom", DbType = "VARCHAR")]
        public string ReservationFrom { get; set; }

        [Column(Name = "ReservationTo", DbType = "VARCHAR")]
        public string ReservationTo { get; set; }

        [Column(Name = "ReservationStatus", DbType = "VARCHAR")]
        public string ReservationStatus { get; set; }

        [Column(Name = "ReservationBy", DbType = "VARCHAR")]
        public string ReservationBy { get; set; }

        [Column(Name = "ReservationFor", DbType = "VARCHAR")]
        public string ReservationFor { get; set; }

        [Column(Name = "ReservationIn", DbType = "VARCHAR")]
        public string ReservationIn { get; set; }

        [Column(Name = "ReservationService", DbType = "VARCHAR")]
        public string ReservationService { get; set; }

    }
}
