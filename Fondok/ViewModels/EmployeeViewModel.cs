
using Fondok.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fondok.Views.Windows;
using Fondok.Context;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using Fondok.Commands;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Data;

namespace Fondok.ViewModels
{
    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // EmployeeViewModel Class
    class EmployeeViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        //Constructor Null FirstTime
        public EmployeeViewModel() : this(null) { }
        // Constructor With Param Of The Model
        public EmployeeViewModel(Employee Employee)
        {
            // Add Employee To Edit
            EditEmployee = Employee;

            //Validate Property
            IsValidProperty = false;

            //Make Properties With Fields Values
            EmployeeUserName = EditEmployee.EmployeeUserName;
            EmployeePassWord = EditEmployee.EmployeePassWord;
            EmployeePhone = EditEmployee.EmployeePhone;
            EmployeeJob = EditEmployee.EmployeeJob;
            EmployeeFirstName = EditEmployee.EmployeeFirstName;
            EmployeeLastName = EditEmployee.EmployeeLastName;
            EmployeeDateOfBirth = EditEmployee.EmployeeDateOfBirth;

            // EmployeeDateOfBirth Get 01/01/0001 First Time?? 
            if (EmployeeDateOfBirth == DateTime.MinValue)
            {
                EmployeeDateOfBirth =new DateTime(1995,08,25);
            }
        }


        //IsValidProperty For Validation
        private bool _IsValidProperty;
        public bool IsValidProperty
        {
            get
            {
                return _IsValidProperty;
            }
            set
            {
                if (_IsValidProperty != value)
                {
                    _IsValidProperty = value;
                    NotifyPropertyChanged("IsValidProperty");
                }
            }
        }

        // Implementation Of IDataErrorInfo For Validation
        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        // EmployeeUserName Property
        private string _EmployeeUserName;
        public string EmployeeUserName
        {
            get
            {
                return _EmployeeUserName;
            }
            set
            {
                if (_EmployeeUserName != value)
                {
                    _EmployeeUserName = value;
                    EditEmployee.EmployeeUserName = _EmployeeUserName;
                    NotifyPropertyChanged("EmployeeUserName");
                }
            }
        }

        // EmployeePassWord Property
        private string _EmployeePassWord;
        public string EmployeePassWord
        {
            get
            {
                return _EmployeePassWord;
            }
            set
            {
                if (_EmployeePassWord != value)
                {
                    _EmployeePassWord = value;

                    EditEmployee.EmployeePassWord = _EmployeePassWord;

                    NotifyPropertyChanged("EmployeePassWord");

                }
            }
        }

        // EmployeePhone Property
        private int _EmployeePhone;
        public int EmployeePhone
        {
            get
            {
                return _EmployeePhone;
            }
            set
            {
                if (_EmployeePhone != value)
                {
                    _EmployeePhone = value;

                    EditEmployee.EmployeePhone = _EmployeePhone;

                    NotifyPropertyChanged("EmployeePhone");
                }
            }
        }

        // EmployeeJob Property
        private string _EmployeeJob;
        public string EmployeeJob
        {
            get
            {
                return _EmployeeJob;
            }
            set
            {
                if (_EmployeeJob != value)
                {
                    _EmployeeJob = value;

                    EditEmployee.EmployeeJob = _EmployeeJob;

                    NotifyPropertyChanged("EmployeeJob");

                }
            }
        }

        // EmployeeFirstName Property
        private string _EmployeeFirstName;
        public string EmployeeFirstName
        {
            get
            {
                return _EmployeeFirstName;
            }
            set
            {
                if (_EmployeeFirstName != value)
                {
                    _EmployeeFirstName = value;

                    EditEmployee.EmployeeFirstName = _EmployeeFirstName;

                    NotifyPropertyChanged("EmployeeFirstName");
                }
            }
        }

        // EmployeeLastName Property
        private string _EmployeeLastName;
        public string EmployeeLastName
        {
            get
            {
                return _EmployeeLastName;
            }
            set
            {
                if (_EmployeeLastName != value)
                {
                    _EmployeeLastName = value;

                    EditEmployee.EmployeeLastName = _EmployeeLastName;

                    NotifyPropertyChanged("EmployeeLastName");
                }
            }
        }

        // EmployeeDateOfBirth Property
        private DateTime _EmployeeDateOfBirth;
        public DateTime EmployeeDateOfBirth
        {
            get
            {
                return _EmployeeDateOfBirth;
            }
            set
            {
                if (_EmployeeDateOfBirth != value)
                {
                    _EmployeeDateOfBirth = value;

                    EditEmployee.EmployeeDateOfBirth = _EmployeeDateOfBirth;

                    NotifyPropertyChanged("EmployeeDateOfBirth");
                }
            }
        }

        // Add Conditions & Error Messages
        public string this[string columnName]
        {
            get
            {
                string FillRequired = "Please Fill The Field";
                switch (columnName)
                {
                    case "EmployeeUserName":
                        if (EmployeeUserName == null || EmployeeUserName == "") return FillRequired;

                        break;
                    case "EmployeePassWord":
                        if (EmployeePassWord == null || EmployeePassWord == "") return FillRequired;

                        break;
                    case "EmployeePhone":
                        if (EmployeePhone <= 0) return FillRequired;

                        break;
                    case "EmployeeJob":
                        if (EmployeeJob == null) return FillRequired;

                        break;
                    case "EmployeeFirstName":
                        if (EmployeeFirstName == null) return FillRequired;

                        break;
                    case "EmployeeLastName":
                        if (EmployeeLastName == null) return FillRequired;

                        break;

                    case "EmployeeDateOfBirth":
                        if (EmployeeDateOfBirth > DateTime.Now.AddYears(-10) || EmployeeDateOfBirth < DateTime.Now.AddYears(-100))
                            return "Date Range: " + DateTime.Now.AddYears(-100).Date + " & " + DateTime.Now.AddYears(-10).Date;

                        break;
                }
                return string.Empty;
            }
        }

        // Edit Employee Property
        private Employee _editEmployee;
        public Employee EditEmployee
        {
            get
            {
                return _editEmployee;
            }
            set
            {
                _editEmployee = value;

                NotifyPropertyChanged("EditEmployee");
            }
        }

        // EmployeeWindow Run() Method
        public bool Run()
        {
            EmployeeWindow window = new EmployeeWindow();

            window.DataContext = this;

            if (window.ShowDialog() == true) { return true; }
            return false;
        }

        // MVVM NotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // EmployeeDataInteraction Class Create, Read, Update, Delete
    class EmployeeDataInteraction
    {
        // Loading Data From DB 
        DatabaseContext db = new DatabaseContext();

        // EmployeeDataInteraction Constructor
        public EmployeeDataInteraction(DatabaseContext _db)
        {
            db = _db;
            db.Employees.Load();
        }
        // Insert Data From To BindingList
        public System.ComponentModel.BindingList<Employee> GetAllEmployees()
        {
            return db.Employees.Local.ToBindingList();
        }

        // Adding Method
        public void AddEmployee(Employee Employee)
        {
            db.Employees.Add(Employee);
            db.SaveChanges();
        }

        // Get Employee Method
        public Employee GetEmployee(int id)
        {
            return db.Employees.Where(get => get.EmployeeID.Equals(id)).First();
        }

        // Update Employee Method FirstTime
        public void UpdateEmployee(
            int EmployeeID,
            string EmployeeUserName,
            string EmployeePassWord,
            int EmployeePhone,
            string EmployeeJob,
            string EmployeeFirstName,
            string EmployeeLastName,
            DateTime EmployeeDateOfBirth
            )
        {
            Employee Employee = GetEmployee(EmployeeID);
            Employee.EmployeeUserName = EmployeeUserName;
            Employee.EmployeePassWord = EmployeePassWord;
            Employee.EmployeePhone = EmployeePhone;
            Employee.EmployeeJob = EmployeeJob;
            Employee.EmployeeFirstName = EmployeeFirstName;
            Employee.EmployeeLastName = EmployeeLastName;
            Employee.EmployeeDateOfBirth = EmployeeDateOfBirth;

            db.SaveChanges();
        }

        // Update Employee Method After Insert
        public void UpdateEmployee(Employee update)
        {
            UpdateEmployee(
                update.EmployeeID,
                update.EmployeeUserName,
                update.EmployeePassWord,
                update.EmployeePhone,
                update.EmployeeJob,
                update.EmployeeFirstName,
                update.EmployeeLastName,
                update.EmployeeDateOfBirth
                );
        }

        // Delete Employee Method
        public void DeleteEmployee(int id)
        {
            db.Employees.Remove(GetEmployee(id));
            db.SaveChanges();
        }
    }


    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // EmployeeBox Class
    class EmployeeBox : INotifyPropertyChanged
    {
        private EmployeeDataInteraction box;
        private DatabaseContext db;
        private BindingList<Employee> _Employees;

        // Employees BindingList Property
        public BindingList<Employee> Employees
        {
            get
            {
                return _Employees;
            }
            set
            {
                _Employees = value;
                NotifyPropertyChanged("Employees");
            }
        }

        // SelectedEmployee Property
        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                NotifyPropertyChanged("SelectedEmployee");
            }
        }

        // EmployeeBox Constructor
        public EmployeeBox()
        {
            db = new DatabaseContext();
            box = new EmployeeDataInteraction(db);
            Employees = box.GetAllEmployees();
            deleteCommand = new DelegateCommand(DeleteEmployee);
            updateCommand = new DelegateCommand(UpdateEmployee);
            createCommand = new DelegateCommand(CreateEmployee);
        }

        // Check if Employee Selected?
        public bool IsSelected()
        {
            return SelectedEmployee != null;
        }

        // Implementation Of DeleteCommand Property
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }

        // Delete the Selected Employee Method & Refresh Employees Binding :)
        public void DeleteEmployee()
        {
            if (!IsSelected())
            {
                return;
            }
            box.DeleteEmployee(SelectedEmployee.EmployeeID);
            Employees.ResetBindings();
        }

        // Implementation Of UpdateCommand Property
        private DelegateCommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }

        // Update the Selected Employee Method & Refresh Employees Binding :)
        public void UpdateEmployee()
        {
            // Check If Selected?
            if (!IsSelected())
            {
                return;
            }

            // Create View Model With Selected Employee To Edit
            EmployeeViewModel vm = new EmployeeViewModel(SelectedEmployee);

            // Run The Employee Window And Add Selected Employee To Edit & Refresh Binding
            if (vm.Run())
            {
                box.UpdateEmployee(SelectedEmployee);
                Employees.ResetBindings();
            }
        }

        // Implementation Of CreateCommand Property
        private DelegateCommand createCommand;
        public ICommand CreateCommand
        {
            get
            {
                return createCommand;
            }
        }

        //  Create Employee Method & Refresh Employees Binding :)
        public void CreateEmployee()
        {
            Employee create = new Employee();

            EmployeeViewModel vm = new EmployeeViewModel(create);

            // Run The Employee Window To Create Employee & Refresh Binding
            if (vm.Run())
            {
                box.AddEmployee(create);

                Employees.ResetBindings();
            }
        }

        // MVVM NotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}