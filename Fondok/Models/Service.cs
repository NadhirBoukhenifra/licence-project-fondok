using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace Fondok.Models
{
    [Table(Name = "Services")]
    public class Service
    {
        [Column(Name = "ServiceID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ServiceID { get; set; }

        [Column(Name = "ServiceTitle", DbType = "VARCHAR")]
        public string ServiceTitle { get; set; }

        [Column(Name = "ServiceResponsible", DbType = "VARCHAR")]
        public string ServiceResponsible { get; set; }

        [Column(Name = "ServicePrice", DbType = "INTEGER")]
        public int ServicePrice { get; set; }

    }
}
