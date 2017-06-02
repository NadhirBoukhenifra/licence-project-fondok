using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace Fondok.Models
{
    [Table(Name = "Services")]
    public class Service
    {
        [Column(Name = "ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int ID { get; set; }

        [Column(Name = "Title", DbType = "VARCHAR")]
        public string Title { get; set; }

        [Column(Name = "Responsible", DbType = "VARCHAR")]
        public string Responsible { get; set; }

        [Column(Name = "Duration", DbType = "INTEGER")]
        public int Duration { get; set; }

        [Column(Name = "Price", DbType = "DOUBLE")]
        public double Price { get; set; }

    }
}
