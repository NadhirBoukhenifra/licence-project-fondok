using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace Fondok.Models
{
    [Table(Name = "Employees")]
    public class Employee
    {
        [Column(Name = "EmployeeID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int EmployeeID { get; set; }

        [Column(Name = "EmployeeUserName", DbType = "VARCHAR")]
        public string EmployeeUserName { get; set; }

        [Column(Name = "EmployeePassWord", DbType = "VARCHAR")]
        public string EmployeePassWord { get; set; }

        [Column(Name = "EmployeeEMail", DbType = "VARCHAR")]
        public string EmployeeEMail { get; set; }

        [Column(Name = "EmployeeJob", DbType = "VARCHAR")]
        public string EmployeeJob { get; set; }

        [Column(Name = "EmployeeFirsName", DbType = "VARCHAR")]
        public string EmployeeFirsName { get; set; }

        [Column(Name = "EmployeeLastName", DbType = "VARCHAR")]
        public string EmployeeLastName { get; set; }

        [Column(Name = "EmployeeDateOfBirth", DbType = "VARCHAR")]
        public string EmployeeDateOfBirth { get; set; }


    }
}
