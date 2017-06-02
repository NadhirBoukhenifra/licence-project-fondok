using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace Fondok.Models
{
   

    [Table(Name = "Book")]
    public class Book
    {
        [Column(Name = "id", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int id { get; set; }

        [Column(Name = "name", DbType = "VARCHAR")]
        public string name { get; set; }

        [Column(Name = "author", DbType = "VARCHAR")]
        public string author { get; set; }

        [Column(Name = "pages", DbType = "INTEGER")]
        public int pages { get; set; }

        [Column(Name = "count", DbType = "INTEGER")]
        public int count { get; set; }

        [Column(Name = "edition", DbType = "INTEGER")]
        public int edition { get; set; }

        
    }
}
