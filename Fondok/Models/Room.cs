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

    [Table(Name = "Rooms")]
    public class Room
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
