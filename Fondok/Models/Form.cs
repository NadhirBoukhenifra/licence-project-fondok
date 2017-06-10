using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace Fondok.Models
{
    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------

    // Forms Table
    [Table(Name = "Forms")]

    // Form Class With Table Columns & Types
    public class Form
    {
        [Column(Name = "FormID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int FormID { get; set; }

        [Column(Name = "FormTitle", DbType = "VARCHAR")]
        public string FormTitle { get; set; }

        [Column(Name = "FormPrice", DbType = "DOUBLE")]
        public double FormPrice { get; set; }
    }
}
