using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace Fondok.Models
{
    [Table(Name = "Invoices")]
    public class Invoice
    {
        [Column(Name = "InvoiceID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int InvoiceID { get; set; }

        [Column(Name = "InvoiceNumber", DbType = "VARCHAR")]
        public string InvoiceNumber { get; set; }

        [Column(Name = "InvoiceDateTime", DbType = "VARCHAR")]
        public string InvoiceDateTime { get; set; }

    }
}
