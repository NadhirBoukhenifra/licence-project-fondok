using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace Fondok.Models
{

    [Table(Name = "Rooms")]
    public class Room
    {
        [Column(Name = "RoomID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int RoomID { get; set; }

        [Column(Name = "RoomNumber", DbType = "VARCHAR")]
        public string RoomNumber { get; set; }

        [Column(Name = "RoomFloor", DbType = "VARCHAR")]
        public string RoomFloor { get; set; }

        [Column(Name = "RoomType", DbType = "VARCHAR")]
        public string RoomType { get; set; }

        [Column(Name = "RoomCapacity", DbType = "VARCHAR")]
        public string RoomCapacity { get; set; }

        [Column(Name = "RoomStatus", DbType = "VARCHAR")]
        public string RoomStatus { get; set; }

        [Column(Name = "RoomPrice", DbType = "VARCHAR")]
        public string RoomPrice { get; set; }
        
    }
}
