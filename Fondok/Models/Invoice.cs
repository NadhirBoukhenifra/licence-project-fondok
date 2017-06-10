using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace Fondok.Models
{
    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------

    // Invoices Table
    [Table(Name = "Invoices")]

    // Invoice Class With Table Columns & Types
    public class Invoice
    {
        [Column(Name = "InvoiceID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int InvoiceID { get; set; }

        [Column(Name = "ReservationID", DbType = "INTEGER")]
        public int ReservationID { get; set; }

        [Column(Name = "InvoiceDateTime", DbType = "DATE")]
        public DateTime InvoiceDateTime { get; set; }

        [Column(Name = "InvoiceTypePayment", DbType = "VARCHAR")]
        public string InvoiceTypePayment { get; set; }

        [Column(Name = "InvoiceTotal", DbType = "DOUBLE")]
        public double InvoiceTotal { get; set; }

    }
}
