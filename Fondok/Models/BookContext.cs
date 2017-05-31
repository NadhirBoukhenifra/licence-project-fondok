using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Fondok.Models
{
    class BookContext : DbContext
    {
        public BookContext() : base("DbConnection")
        { }

        public DbSet<Book> Books { get; set; }
    }
}
