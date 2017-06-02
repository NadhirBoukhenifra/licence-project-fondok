using Fondok.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fondok.Context
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = "C:\\USERS\\Nadhir\\Desktop\\data.db", ForeignKeys = true }.ConnectionString
            }, true)
        {
        }
      

        //public DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Service> Services { get; set; }
    }

}
