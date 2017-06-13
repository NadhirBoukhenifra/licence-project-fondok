
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
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Windows;

namespace Fondok.ViewModels
{
    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // InvoiceViewModel Class
    class InvoiceViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        //Constructor Null FirstTime
        public InvoiceViewModel() : this(null) { }
        // Constructor With Param Of The Model
        public InvoiceViewModel(Invoice Invoice)
        {
            // Add Invoice To Edit
            EditInvoice = Invoice;

            //Validate Property
            IsValidProperty = false;

            //Make Properties With Fields Values
            ReservationID = EditInvoice.ReservationID;
            InvoiceDateTime = EditInvoice.InvoiceDateTime.Date;
            InvoiceTypePayment = InvoiceTypePayment;
            InvoiceTotal = EditInvoice.InvoiceTotal;

            // InvoiceDateOfBirth Get 01/01/0001 First Time?? 
            if (InvoiceDateTime == DateTime.MinValue)
            {
                InvoiceDateTime = DateTime.Now;
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

        // ReservationID Property
        private int _ReservationID;
        public int ReservationID
        {
            get
            {
                return _ReservationID;
            }
            set
            {
                if (_ReservationID != value)
                {
                    _ReservationID = value;
                    EditInvoice.ReservationID = _ReservationID;
                    NotifyPropertyChanged("ReservationID");
                }
            }
        }

        // InvoiceDateTime Property
        private DateTime _InvoiceDateTime;
        public DateTime InvoiceDateTime
        {
            get
            {
                return _InvoiceDateTime;
            }
            set
            {
                if (_InvoiceDateTime != value)
                {
                    _InvoiceDateTime = value;

                    EditInvoice.InvoiceDateTime = _InvoiceDateTime.Date;

                    NotifyPropertyChanged("InvoiceDateTime");
                }
            }
        }

        // InvoiceTypePayment Property
        private string _InvoiceTypePayment;
        public string InvoiceTypePayment
        {
            get
            {
                return _InvoiceTypePayment;
            }
            set
            {
                if (_InvoiceTypePayment != value)
                {
                    _InvoiceTypePayment = value;

                    EditInvoice.InvoiceTypePayment = _InvoiceTypePayment;

                    NotifyPropertyChanged("InvoiceTypePayment");

                }
            }
        }

        // InvoiceTotal Property
        private double _InvoiceTotal;
        public double InvoiceTotal
        {
            get
            {
                return _InvoiceTotal;
            }
            set
            {
                if (_InvoiceTotal != value)
                {
                    _InvoiceTotal = value;

                    EditInvoice.InvoiceTotal = _InvoiceTotal;

                    NotifyPropertyChanged("InvoiceTotal");
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
                    case "ReservationID":
                        if (ReservationID > 0) return FillRequired;

                        break;
 
                    case "InvoiceDateTime":
                        if (InvoiceDateTime >= DateTime.Now)
                            return "Date Range: >" + DateTime.Now;

                        break;
                    case "InvoiceTypePayment":
                        if (InvoiceTypePayment == null) return FillRequired;

                        break;
                    case "InvoiceTotal":
                        if (InvoiceTotal <= 0) return FillRequired;

                        break;
                }
                return string.Empty;
            }
        }

        // Edit Invoice Property
        private Invoice _editInvoice;
        public Invoice EditInvoice
        {
            get
            {
                return _editInvoice;
            }
            set
            {
                _editInvoice = value;

                NotifyPropertyChanged("EditInvoice");
            }
        }

        // InvoiceWindow Run() Method
        public bool Run()
        {
            InvoiceWindow window = new InvoiceWindow();

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
    // InvoiceDataInteraction Class Create, Read, Update, Delete
    class InvoiceDataInteraction
    {
        // Loading Data From DB 
        DatabaseContext db = new DatabaseContext();

        // InvoiceDataInteraction Constructor
        public InvoiceDataInteraction(DatabaseContext _db)
        {
            db = _db;
            db.Invoices.Load();
        }
        // Insert Data From To BindingList
        public System.ComponentModel.BindingList<Invoice> GetAllInvoices()
        {
            return db.Invoices.Local.ToBindingList();
        }

        // Adding Method
        public void AddInvoice(Invoice Invoice)
        {
            db.Invoices.Add(Invoice);
            db.SaveChanges();
        }

        // Get Invoice Method
        public Invoice GetInvoice(int id)
        {
            return db.Invoices.Where(get => get.InvoiceID.Equals(id)).First();
        }
        public Reservation GetInvoiceReservation(int id)
        {
            return db.Reservations.Where(get => get.ReservationID.Equals(id)).First();
        }

        // Update Invoice Method FirstTime
        public void UpdateInvoice(
            int InvoiceID,
            int ReservationID,
            DateTime InvoiceDateTime,
            string InvoiceTypePayment,
            double InvoiceTotal
            )
        {
            Invoice Invoice = GetInvoice(InvoiceID);
            Invoice.ReservationID = ReservationID;
            Invoice.InvoiceDateTime = InvoiceDateTime;
            Invoice.InvoiceTypePayment = InvoiceTypePayment;
            Invoice.InvoiceTotal = InvoiceTotal;
            db.SaveChanges();
        }

        // Update Invoice Method After Insert
        public void UpdateInvoice(Invoice update)
        {
            UpdateInvoice(
                update.InvoiceID,
                update.ReservationID,
                update.InvoiceDateTime,
                update.InvoiceTypePayment,
                update.InvoiceTotal
                );
        }

        // Delete Invoice Method
        public void DeleteInvoice(int id)
        {
            db.Invoices.Remove(GetInvoice(id));
            db.SaveChanges();
        }
    }


    // ISIL 2016/2017 NADHIR BOUKHENIFRA, BOUALI MOHAMMED AMIN, HIRECHE ISLEM -------------------------------------------
    // InvoiceBox Class
    class InvoiceBox : INotifyPropertyChanged
    {
        private InvoiceDataInteraction box;
        private DatabaseContext db;
        private BindingList<Invoice> _Invoices;

        // Invoices BindingList Property
        public BindingList<Invoice> Invoices
        {
            get
            {
                return _Invoices;
            }
            set
            {
                _Invoices = value;
                NotifyPropertyChanged("Invoices");
            }
        }

        // SelectedInvoice Property
        private Invoice _selectedInvoice;
        public Invoice SelectedInvoice
        {
            get
            {
                return _selectedInvoice;
            }
            set
            {
                _selectedInvoice = value;
                NotifyPropertyChanged("SelectedInvoice");
            }
        }

        // InvoiceBox Constructor
        public InvoiceBox()
        {
            db = new DatabaseContext();
            box = new InvoiceDataInteraction(db);
            Invoices = box.GetAllInvoices();
            deleteCommand = new DelegateCommand(DeleteInvoice);
            updateCommand = new DelegateCommand(UpdateInvoice);
            createCommand = new DelegateCommand(CreateInvoice);
            printCommand = new DelegateCommand(PrintInvoice);
        }

        // Check if Invoice Selected?
        public bool IsSelected()
        {
            return SelectedInvoice != null;
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
        private ICommand printCommand;
        public ICommand PrintCommand
        {
            get
            {
                return printCommand;
            }
        }

        // Delete the Selected Invoice Method & Refresh Invoices Binding :)
        public void DeleteInvoice()
        {
            if (!IsSelected())
            {
                return;
            }
            box.DeleteInvoice(SelectedInvoice.InvoiceID);
            Invoices.ResetBindings();
        }

        public void PrintInvoice()
        {
            if (!IsSelected())
            {
                return;
            }

            //// Create the print dialog object and set options
            //PrintDialog pDialog = new PrintDialog();
            //pDialog.PageRangeSelection = PageRangeSelection.AllPages;
            //pDialog.UserPageRangeEnabled = true;

            //// Display the dialog. This returns true if the user presses the Print button.
            //Nullable<Boolean> print = pDialog.ShowDialog();
            //if (print == true)
            //{
            //    XpsDocument xpsDocument = new XpsDocument(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FixedDocumentSequence.xps", FileAccess.ReadWrite);
            //    FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
            //    pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");
            //}
            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Invoice" + box.GetInvoice(SelectedInvoice.InvoiceID).InvoiceID.ToString() +
                box.GetInvoice(SelectedInvoice.InvoiceID).InvoiceDateTime.ToString();
            MessageBox.Show(box.GetInvoice(SelectedInvoice.InvoiceID).InvoiceDateTime.ToString());
            MessageBox.Show(box.GetInvoice(SelectedInvoice.InvoiceID).InvoiceID.ToString());
            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont btitle = new XFont("Verdana", 48, XFontStyle.Underline);
            XFont title = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            XFont info = new XFont("Verdana", 8);
            XFont bottom = new XFont("Verdana", 8, XFontStyle.Underline);

            // Draw the text
            gfx.DrawString("Hotel El Khams Njoum", title, XBrushes.Aquamarine,
              new XRect(0, 32, page.Width, page.Height),
              XStringFormats.TopCenter);

            gfx.DrawString("INVOICE", btitle, XBrushes.DarkGray,
              new XRect(0, 84, page.Width, page.Height),
              XStringFormats.TopCenter);

            gfx.DrawString("EMail:  HotelEl@Gmail.com", info, XBrushes.Black,
              new XRect(32, 172, page.Width, page.Height),
              XStringFormats.TopLeft);
            gfx.DrawString("Phone:  +213 0669 59 51 88", info, XBrushes.Black,
              new XRect(32, 184, page.Width, page.Height),
              XStringFormats.TopLeft);
            gfx.DrawString("Tel/Fax:    +213 033 22 33 44", info, XBrushes.Black,
              new XRect(32, 196, page.Width, page.Height),
              XStringFormats.TopLeft);
            gfx.DrawString("WebSite:    www.Hotel.com", info, XBrushes.Black,
              new XRect(32, 208, page.Width, page.Height),
              XStringFormats.TopLeft);


            gfx.DrawString("Invoice ID: " + box.GetInvoice(SelectedInvoice.InvoiceID).InvoiceID.ToString(), info, XBrushes.Black,
             new XRect(396, 172, page.Width, page.Height),
             XStringFormats.TopLeft);

            gfx.DrawString("Reservation ID: " + box.GetInvoice(SelectedInvoice.InvoiceID).ReservationID.ToString(), info, XBrushes.Black,
             new XRect(396, 184, page.Width, page.Height),
             XStringFormats.TopLeft);

            gfx.DrawString("Invoice Type Payment: " + box.GetInvoice(SelectedInvoice.InvoiceID).InvoiceTypePayment.ToString(), info, XBrushes.Black,
             new XRect(396, 196, page.Width, page.Height),
             XStringFormats.TopLeft);

            gfx.DrawString("Invoice Date Time: " + box.GetInvoice(SelectedInvoice.InvoiceID).InvoiceDateTime.ToString(), info, XBrushes.Black,
           new XRect(396, 208, page.Width, page.Height),
           XStringFormats.TopLeft);



            gfx.DrawString("Reserved By: " + box.GetInvoiceReservation(SelectedInvoice.ReservationID).ReservedBy + " | Room Number: " + 
                box.GetInvoiceReservation(SelectedInvoice.ReservationID).RoomNumber+" | Payed By: "+ box.GetInvoiceReservation(SelectedInvoice.ReservationID).ReservedFor, info, XBrushes.Black,
           new XRect(0, 256, page.Width, page.Height),
           XStringFormats.TopCenter);

           

            gfx.DrawString("Invoice Total: " + box.GetInvoice(SelectedInvoice.InvoiceID).InvoiceTotal.ToString()+" DA", title, XBrushes.Red,
         new XRect(0, 315, page.Width, page.Height),
         XStringFormats.TopCenter);

            gfx.DrawString("Responsible receptionist signature : " , bottom, XBrushes.DarkGray,
         new XRect(32, 500, page.Width, page.Height),
         XStringFormats.TopLeft);

            //  gfx.DrawString("Invoice Total: " + box.GetInvoice(SelectedInvoice.InvoiceID).InvoiceTotal.ToString() +" DZD" , info, XBrushes.Green,
            //new XRect(0, 300, page.Width, page.Height),
            //XStringFormats.TopCenter);







            // Save the document... Amin mod (save it to the invoices folder)
            string filename = string.Format("..\\..\\..\\Invoices\\Invoice_{0}_{1:dd.MM.yyyy_hh-mm-ss}.pdf",
                box.GetInvoice(SelectedInvoice.InvoiceID).InvoiceID,
                box.GetInvoice(SelectedInvoice.InvoiceID).InvoiceDateTime);

            document.Save(filename);
            
            // ...and start a viewer.
            Process.Start(filename);

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

        // Update the Selected Invoice Method & Refresh Invoices Binding :)
        public void UpdateInvoice()
        {
            // Check If Selected?
            if (!IsSelected())
            {
                return;
            }

            // Create View Model With Selected Invoice To Edit
            InvoiceViewModel vm = new InvoiceViewModel(SelectedInvoice);

            // Run The Invoice Window And Add Selected Invoice To Edit & Refresh Binding
            if (vm.Run())
            {
                box.UpdateInvoice(SelectedInvoice);
                Invoices.ResetBindings();
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

        //  Create Invoice Method & Refresh Invoices Binding :)
        public void CreateInvoice()
        {
            Invoice create = new Invoice();

            InvoiceViewModel vm = new InvoiceViewModel(create);

            // Run The Invoice Window To Create Invoice & Refresh Binding
            if (vm.Run())
            {
                box.AddInvoice(create);

                Invoices.ResetBindings();
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