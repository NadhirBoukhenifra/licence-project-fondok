using Fondok.Context;
using Fondok.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fondok.ViewModels
{
    class LoginViewModel : BindableBase
    {
        private string _title = "Welcome to Hotel Manager V 1.0";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        //DatabaseContext context = new DatabaseContext();
        //Employee employee = new Employee();
        //    string username;
        //    string password;


        //Employee employee = new Employee()
        //{
        //    EmpName = name,
        //    Designation = designation,
        //    Salary = salary
        //};

        //context.Employee.Add(employee);

            //context.SaveChanges();

            //foreach (var item in data)
            //{
            //    Console.Write(string.Format("ID : {0}  Name : {1}  Salary : {2}   Designation : {3}{4}", item.ID, item.EmpName, item.Salary, item.Designation, Environment.NewLine));
            //}

    }
}