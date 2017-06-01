using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fondok.Models
{
    //public class RoomsModel
    //{
    //    public RoomsModel() { }
    //    private string _room_id; public string ID { get { return _room_id; } set { _room_id = value; } }
    //    private string _room_type; public string RoomType { get { return _room_type; } set { _room_type = value; } }
    //    private string _reserved; public string Reserved { get { return _reserved; } set { _reserved = value; } }
    //    private string _reserved_from; public string ReservedFrom { get { return _reserved_from; } set { _reserved_from = value; } }
    //    private string _reserved_to; public string ReservedTo { get { return _reserved_to; } set { _reserved_to = value; } }
    //    private string _reserved_by; public string ReservedBy { get { return _reserved_by; } set { _reserved_by = value; } }
    //}

    [Table(Name = "Rooms")]
    public class Rooms
    {
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Column(Name = "Type", DbType = "VARCHAR")]
        public string Type { get; set; }

        [Column(Name = "Reserved", DbType = "VARCHAR")]
        public string Reserved { get; set; }

        [Column(Name = "ReservedFrom", DbType = "VARCHAR")]
        public string ReservedFrom { get; set; }

        [Column(Name = "ReservedTo", DbType = "VARCHAR")]
        public string ReservedTo { get; set; }

        [Column(Name = "ReservedBy", DbType = "VARCHAR")]
        public string ReservedBy { get; set; }

        [Column(Name = "Price", DbType = "DOUBLE")]
        public double Price { get; set; }


    }
}
