using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace Fondok.Models
{
    [Table(Name = "Clients")]
    public class Client
    {
        [Column(Name = "ClientID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ClientID { get; set; }

        [Column(Name = "ClientFirstName", DbType = "VARCHAR")]
        public string ClientFirstName { get; set; }

        [Column(Name = "ClientLastName", DbType = "INTEGER")]
        public int ClientLastName { get; set; }

        [Column(Name = "ClientDateOfBirth", DbType = "DATE")]
        public DateTime ClientDateOfBirth { get; set; }

    }
}
