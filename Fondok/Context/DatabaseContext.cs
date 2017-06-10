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
                ConnectionString = new SQLiteConnectionStringBuilder() {
                    DataSource = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\fondok.db", ForeignKeys = true }.ConnectionString
            }, true)
        {
        }




        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
    }

}
