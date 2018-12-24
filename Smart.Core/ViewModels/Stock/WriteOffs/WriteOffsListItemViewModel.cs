using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides data which <see cref="WriteOffsListItemControl"> can display
    /// </summary>
    public class WriteOffsListItemViewModel:BaseViewModel
    {
        #region PrivateMembers

        /// <summary>
        /// Currently selected write-off item
        /// </summary>
        private static WriteOffsListItemViewModel mCurrentlySelectedWriteOffItem = null;

        /// <summary>
        /// Invoice number for this write-off
        /// </summary>
        private string mInvoiceNumber = String.Empty;
        #endregion

        #region Public properties





        /// <summary>
        /// The status of this write-off
        /// </summary>
        public WriteOffStatus Status { get; set; }

        /// <summary>
        /// The number of products to be writen off
        /// </summary>
        public int ItemsCount { get; set; }

        /// <summary>
        /// The number of this write-off
        /// </summary>
        public string WriteOffNumber { get; set; }

        /// <summary>
        /// The invoice number of this write-off
        /// </summary>
        public string InvoiceNumber
        {
            get => String.IsNullOrEmpty(mInvoiceNumber) ? @"<не создана>" : mInvoiceNumber;
            set => mInvoiceNumber = value;
        }


        /// <summary>
        /// The date this write-off was created
        /// </summary>
        public DateTime CreationDate { get; set; }


        /// <summary>
        /// Price of this write-off
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Indicates if this write-off item is currently selected
        /// </summary>
        public bool IsSelected { get; private set; } = false;

        /// <summary>
        /// Indicates if more region is open now
        /// </summary>
        public bool IsMoreOpen { get; private set; } = false;

        #endregion

        #region Public commands
        /// <summary>
        /// A command to select this write-off item
        /// </summary>
        public ICommand SelectCommand { get; set; }

        /// <summary>
        /// A command to open current write-off
        /// </summary>
        public ICommand OpenWriteOffCommand { get; set; }


        /// <summary>
        /// A command to open more region
        /// </summary>
        public ICommand OpenMoreCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public WriteOffsListItemViewModel()
        {
            //Initialize commands
            SelectCommand = new RelayCommand(Select);
            OpenWriteOffCommand = new RelayCommand(OpenWriteOff);
            OpenMoreCommand = new RelayCommand(OpenMore);

            //Hook into the CurrentWriteOffNumberNullChanged event
            IoC.Stock.CurrentWriteOffNumberNullChanged += Unselect;
        }
        #endregion

        #region Private Helpers

        /// <summary>
        /// Unselects currently selected write-off
        /// </summary>
        private void Unselect()
        {

            //Unselect any curent write-off item 
            if (mCurrentlySelectedWriteOffItem != null)
                mCurrentlySelectedWriteOffItem.IsSelected = false;

            //Set currently selected item to null
            mCurrentlySelectedWriteOffItem = null;

            //If more region is currently open, close it
            if (IsMoreOpen)
                IsMoreOpen = false;

        }
        #endregion


        #region Command Methods

        /// <summary>
        /// Selects current supply item
        /// </summary>
        private void Select()
        {
            //If this item is currently selected, do nothing
            if (mCurrentlySelectedWriteOffItem == this)
                return;

            //Try to get int value from the WriteOffNumber string
            if (Int32.TryParse(WriteOffNumber, out int writeOffNumber))
            {
                //Unselect previous write-off item
                if (mCurrentlySelectedWriteOffItem != null)
                {
                    //If more region is currently open in the previous selected item, close it
                    if (mCurrentlySelectedWriteOffItem.IsMoreOpen)
                        mCurrentlySelectedWriteOffItem.IsMoreOpen = false;

                    //Unselect previous write-off item
                    mCurrentlySelectedWriteOffItem.IsSelected = false;
                }
                //Sets a single instance of CurrentWriteOffNumber to this write-off's number
                IoC.Stock.CurrentWriteOffNumber = writeOffNumber;
                //Set this item to be currently selected
                IsSelected = true;
                mCurrentlySelectedWriteOffItem = this;
            }
            else
                //Something went wrong
                throw new ArgumentException("Cannot recognize this write-off number");

        }

        /// <summary>
        /// Opens curent write-off item
        /// Due to issue with double click action,
        /// when very fast double click never fires single click event
        /// </summary>
        private void OpenWriteOff()
        {
            //Select this write-off
            Select();

            //Ask shared view model to open currently selected supply
            IoC.Stock.InfoWriteOffCommand.Execute(null);

        }

        /// <summary>
        /// Opens more region or close it
        /// </summary>
        private void OpenMore()
        {
            //Select this item
            Select();

            //Inverts current value
            IsMoreOpen = !IsMoreOpen;

        }


        #endregion
    }
}
