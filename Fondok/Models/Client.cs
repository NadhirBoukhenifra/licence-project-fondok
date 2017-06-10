using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace Fondok.Models
{
    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------

    // Clients Table
    [Table(Name = "Clients")]

    // Client Class With Table Columns & Types
    public class Client
    {
        [Column(Name = "ClientID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ClientID { get; set; }

        [Column(Name = "ClientFirstName", DbType = "VARCHAR")]
        public string ClientFirstName { get; set; }

        [Column(Name = "ClientLastName", DbType = "VARCHAR")]
        public string ClientLastName { get; set; }

        [Column(Name = "ClientDateOfBirth", DbType = "DATE")]
        public DateTime ClientDateOfBirth { get; set; }

        [Column(Name = "ClientGender", DbType = "VARCHAR")]
        public string ClientGender { get; set; }

        [Column(Name = "ClientIDType", DbType = "VARCHAR")]
        public string ClientIDType { get; set; }

        [Column(Name = "ClientIDNumber", DbType = "INTEGER")]
        public int ClientIDNumber { get; set; }

        [Column(Name = "ClientParent", DbType = "VARCHAR")]
        public string ClientParent { get; set; }
    }
}
