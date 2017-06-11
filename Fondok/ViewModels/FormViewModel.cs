
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
    // FormViewModel Class
    class FormViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        //Constructor Null FirstTime
        public FormViewModel() : this(null) { }
        // Constructor With Param Of The Model
        public FormViewModel(Form Form)
        {
            // Add Form To Edit
            EditForm = Form;

            //Validate Property
            IsValidProperty = false;

            //Make Properties With Fields Values
            FormTitle = EditForm.FormTitle;
            FormPrice = EditForm.FormPrice;

           

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

        // FormTitle Property
        private string _FormTitle;
        public string FormTitle
        {
            get
            {
                return _FormTitle;
            }
            set
            {
                if (_FormTitle != value)
                {
                    _FormTitle = value;
                    EditForm.FormTitle = _FormTitle;
                    NotifyPropertyChanged("FormTitle");
                }
            }
        }

        // FormLastName Property
        private double _FormPrice;
        public double FormPrice
        {
            get
            {
                return _FormPrice;
            }
            set
            {
                if (_FormPrice != value)
                {
                    _FormPrice = value;

                    EditForm.FormPrice = _FormPrice;

                    NotifyPropertyChanged("FormPrice");

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
                    case "FormTitle":
                        if (FormTitle == null || FormTitle == "") return FillRequired;

                        break;
                    case "FormPrice":
                        if (FormPrice <= 0 ) return FillRequired;

                        break;
                }
                return string.Empty;
            }
        }

        // Edit Form Property
        private Form _editForm;
        public Form EditForm
        {
            get
            {
                return _editForm;
            }
            set
            {
                _editForm = value;

                NotifyPropertyChanged("EditForm");
            }
        }

        // FormWindow Run() Method
        public bool Run()
        {
            FormWindow window = new FormWindow();

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
    // FormDataInteraction Class Create, Read, Update, Delete
    class FormDataInteraction
    {
        // Loading Data From DB 
        DatabaseContext db = new DatabaseContext();

        // FormDataInteraction Constructor
        public FormDataInteraction(DatabaseContext _db)
        {
            db = _db;
            db.Forms.Load();
        }
        // Insert Data From To BindingList
        public System.ComponentModel.BindingList<Form> GetAllForms()
        {
            return db.Forms.Local.ToBindingList();
        }

        // Adding Method
        public void AddForm(Form Form)
        {
            db.Forms.Add(Form);
            db.SaveChanges();
        }

        // Get Form Method
        public Form GetForm(int id)
        {
            return db.Forms.Where(get => get.FormID.Equals(id)).First();
        }

        public Form GetFormTitle(string title)
        {
            return db.Forms.Where(get => get.FormTitle.Equals(title)).First();
        }

        // Update Form Method FirstTime
        public void UpdateForm(
            int FormID,
            string FormTitle,
            double FormPrice

            )
        {
            Form Form = GetForm(FormID);
            Form.FormTitle = FormTitle;
            Form.FormPrice = FormPrice;


            db.SaveChanges();
        }

        // Update Form Method After Insert
        public void UpdateForm(Form update)
        {
            UpdateForm(
                update.FormID,
                update.FormTitle,
                update.FormPrice

                );
        }

        // Delete Form Method
        public void DeleteForm(int id)
        {
            db.Forms.Remove(GetForm(id));
            db.SaveChanges();
        }
    }


    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // FormBox Class
    class FormBox : INotifyPropertyChanged
    {
        private FormDataInteraction box;
        private DatabaseContext db;
        private BindingList<Form> _Forms;

        // Forms BindingList Property
        public BindingList<Form> Forms
        {
            get
            {
                return _Forms;
            }
            set
            {
                _Forms = value;
                NotifyPropertyChanged("Forms");
            }
        }

        // SelectedForm Property
        private Form _selectedForm;
        public Form SelectedForm
        {
            get
            {
                return _selectedForm;
            }
            set
            {
                _selectedForm = value;
                NotifyPropertyChanged("SelectedForm");
            }
        }

        // FormBox Constructor
        public FormBox()
        {
            db = new DatabaseContext();
            box = new FormDataInteraction(db);
            Forms = box.GetAllForms();
            deleteCommand = new DelegateCommand(DeleteForm);
            updateCommand = new DelegateCommand(UpdateForm);
            createCommand = new DelegateCommand(CreateForm);
        }

        // Check if Form Selected?
        public bool IsSelected()
        {
            return SelectedForm != null;
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

        // Delete the Selected Form Method & Refresh Forms Binding :)
        public void DeleteForm()
        {
            if (!IsSelected())
            {
                return;
            }
            box.DeleteForm(SelectedForm.FormID);
            Forms.ResetBindings();
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

        // Update the Selected Form Method & Refresh Forms Binding :)
        public void UpdateForm()
        {
            // Check If Selected?
            if (!IsSelected())
            {
                return;
            }

            // Create View Model With Selected Form To Edit
            FormViewModel vm = new FormViewModel(SelectedForm);

            // Run The Form Window And Add Selected Form To Edit & Refresh Binding
            if (vm.Run())
            {
                box.UpdateForm(SelectedForm);
                Forms.ResetBindings();
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

        //  Create Form Method & Refresh Forms Binding :)
        public void CreateForm()
        {
            Form create = new Form();

            FormViewModel vm = new FormViewModel(create);

            // Run The Form Window To Create Form & Refresh Binding
            if (vm.Run())
            {
                box.AddForm(create);

                Forms.ResetBindings();
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