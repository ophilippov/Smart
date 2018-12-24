using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core
{
    /// <summary>
    /// ViewModel for the Stock item of the TabMenu
    /// </summary>
    public class AppStockViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// Number of the currently selected order
        /// </summary>
        private int? mCurrentOrderNumber = null;

        /// <summary>
        /// Number of the currently selected supply
        /// </summary>
        private int? mCurrentSupplyNumber = null;

        /// <summary>
        /// Number of the currently selected write-off
        /// </summary>
        private int? mCurrentWriteOffNumber = null;

        /// <summary>
        /// Number of the currently selected product
        /// </summary>
        private int? mCurrentProductArtNumber = null;
        #endregion

        #region Public Events

        /// <summary>
        /// Event that fires when current order changes to null
        /// </summary>
        public event Action CurrentOrderNumberNullChanged;

        /// <summary>
        /// Event that fires when current supply changes to null
        /// </summary>
        public event Action CurrentSupplyNumberNullChanged;
        
        /// <summary>
        /// Event that fires when current write-off changes to null
        /// </summary>
        public event Action CurrentWriteOffNumberNullChanged;

        /// <summary>
        /// Event that fires when current product changes to null
        /// </summary>
        public event Action CurrentProductArtNumberNullChanged;
        #endregion


        #region Public commands

        /// <summary>
        /// A command for rejecting this order
        /// </summary>
        public ICommand RejectOrderCommand { get; set; }

        /// <summary>
        /// A command for approving current order
        /// </summary>
        public ICommand ApproveOrderCommand { get; set; }

        /// <summary>
        /// A command for shipping current order
        /// </summary>
        public ICommand ShipOrderCommand { get; set; }

        /// <summary>
        /// A command for printing current order
        /// </summary>
        public ICommand PrintOrderCommand { get; set; }

        /// <summary>
        /// A command for opening new dialog window with information about customer
        /// </summary>
        public ICommand CustomerInfoOrderCommand { get; set; }

        /// <summary>
        /// A command for opening new dialog window with information about this order
        /// </summary>
        public ICommand InfoOrderCommand { get; set; }

        /// <summary>
        /// A command to open invoice for this order
        /// </summary>
        public ICommand InvoiceOrderCommand { get; set; }

        /// <summary>
        /// A command to set a sort order
        /// </summary>
        public ICommand SortOrderCommand { get; set; }


        /// <summary>
        /// A command add a new product
        /// </summary>
        public ICommand NewProductCommand { get; set; }

        /// <summary>
        /// A command to delete the selected product
        /// </summary>
        public ICommand DeleteProductCommand { get; set; }


        /// <summary>
        /// A command to edit the selected product
        /// </summary>
        public ICommand EditProductCommand { get; set; }


        /// <summary>
        /// A command to get info about the currently selected product
        /// </summary>
        public ICommand InfoProductCommand { get; set; }

        /// <summary>
        /// A command to get info about the supplier of the selected product
        /// </summary>
        public ICommand SupplierInfoProductCommand { get; set; }

        /// <summary>
        /// A command to get info about orders that includes this product
        /// </summary>
        public ICommand OrdersProductCommand { get; set; }

        /// <summary>
        /// A command to set a sort order
        /// </summary>
        public ICommand SortProductCommand { get; set; }

        /// <summary>
        /// A command to create a new Supply
        /// </summary>
        public ICommand NewSupplyCommand { get; set; }

        /// <summary>
        /// A command to delete the current Supply
        /// </summary>
        public ICommand DeleteSupplyCommand { get; set; }


        /// <summary>
        /// A command to edit the current Supply
        /// </summary>
        public ICommand EditSupplyCommand { get; set; }

        /// <summary>
        /// A command to show products this supply provides
        /// </summary>
        public ICommand ProductsSupplyCommand { get; set; }

        /// <summary>
        /// A command to show info about supplier of this supply
        /// </summary>
        public ICommand SupplierInfoSupplyCommand { get; set; }

        /// <summary>
        /// A command to open dialog with payment details
        /// </summary>
        public ICommand PaymentSupplyCommand { get; set; }

        /// <summary>
        /// A command to show invoice for this supply
        /// </summary>
        public ICommand InvoiceSupplyCommand { get; set; }

        /// <summary>
        /// A command to show info about this supply
        /// </summary>
        public ICommand InfoSupplyCommand { get; set; }

        /// <summary>
        /// A command to set a sorting order for supplies
        /// </summary>
        public ICommand SortSupplyCommand { get; set; }


        /// <summary>
        /// A command to create a new write-off
        /// </summary>
        public ICommand NewWriteOffCommand { get; set; }

        /// <summary>
        /// A command to delete current write-off
        /// </summary>
        public ICommand DeleteWriteOffCommand { get; set; }

        /// <summary>
        /// A command to edit current write-off
        /// </summary>
        public ICommand EditWriteOffCommand { get; set; }

        /// <summary>
        /// A command to show info about currently selected write-off
        /// </summary>
        public ICommand InfoWriteOffCommand { get; set; }

        /// <summary>
        /// A command to show an invoice for current write-off
        /// </summary>
        public ICommand InvoiceWriteOffCommand { get; set; }

        /// <summary>
        /// A command to show products included to this write-off
        /// </summary>
        public ICommand ProductsWriteOffCommand { get; set; }


        /// <summary>
        /// A command to set a sort order for write-offs
        /// </summary>
        public ICommand SortWriteOffCommand { get; set; }
        #endregion

        #region Public Properties

        /// <summary>
        /// The currently selected stock menu item category
        /// </summary>
        public StockCategory CurrentCategory { get; set; } = StockCategory.Orders;
       

        /// <summary>
        /// Number of the currently selected order
        /// </summary>
        public int? CurrentOrderNumber
        {
            get => mCurrentOrderNumber;
            set
            {
                mCurrentOrderNumber = value;
                if (value == null)
                {
                    // If value equals to null...
                    CurrentOrderNumberNullChanged();
                }
            }
        }

        /// <summary>
        /// Art number of the currently selected product
        /// </summary>
        public int? CurrentProductArtNumber
        {
            get => mCurrentProductArtNumber;
            set
            {
                mCurrentProductArtNumber = value;
                if (value == null)
                {
                    // If value equals to null...
                    CurrentProductArtNumberNullChanged();
                }
            }
        }

        /// <summary>
        /// The number of the currently selected Supply
        /// </summary>
        public int? CurrentSupplyNumber
        {
            get => mCurrentSupplyNumber;
            set
            {
                mCurrentSupplyNumber = value;
                if (value == null)
                {
                    // If value equals to null...
                    CurrentSupplyNumberNullChanged();
                }
            }
        }

        /// <summary>
        /// The number of the currently selected Write-off
        /// </summary>
        public int? CurrentWriteOffNumber
        {
            get => mCurrentWriteOffNumber;
            set
            {
                mCurrentWriteOffNumber = value;
                if (value == null)
                {
                    // If value equals to null...
                    CurrentWriteOffNumberNullChanged();
                }
            }
        }

        /// <summary>
        /// Number of new orders
        /// </summary>
        public int NewOrdersCount { get; set; }

        /// <summary>
        /// Number of rejected orders
        /// </summary>
        public int RejectedOrdersCount { get; set; }


        /// <summary>
        /// Number of approved orders
        /// </summary>
        public int ApprovedOrdersCount { get; set; }


        /// <summary>
        /// Number of shipped orders
        /// </summary>
        public int ShippedOrdersCount { get; set; }

        /// <summary>
        /// Number of orders transfered to SC
        /// </summary>
        public int TransferedToSCOrdersCount { get; set; }

        /// <summary>
        /// Number of all products
        /// </summary>
        public int AllProductsCount { get; set; }


        /// <summary>
        /// Number of products that have a discount
        /// </summary>
        public int DiscountProductsCount { get; set; }

        /// <summary>
        /// Number of absent products
        /// </summary>
        public int AbsentProductsCount { get; set; }


        /// <summary>
        /// Number of products waiting for supply
        /// </summary>
        public int SupplyWaitingProductsCount { get; set; }

        /// <summary>
        /// Number of products that ends in stock
        /// </summary>
        public int EndingProductsCount { get; set; }



        /// <summary>
        /// A number of all supplies
        /// </summary>
        public int AllSuppliesCount { get; set; }

        /// <summary>
        /// A number of done supplies
        /// </summary>
        public int DoneSuppliesCount { get; set; }

        /// <summary>
        /// A number of supplies that is waiting for payment
        /// </summary>
        public int WaitingForPaymentSuppliesCount { get; set; }

        /// <summary>
        /// A number of new supplies
        /// </summary>
        public int NewSuppliesCount { get; set; }

        /// <summary>
        /// A number of waiting supplies
        /// </summary>
        public int WaitingSuppliesCount { get; set; }

        /// <summary>
        /// A number of supplies with the overdue payment status
        /// </summary>
        public int PaymentOverdueSuppliesCount { get; set; }

        /// <summary>
        /// A number of cancelled supplies 
        /// </summary>
        public int CancelledSuppliesCount { get; set; }


        /// <summary>
        /// A number of all write-offs
        /// </summary>
        public int AllWriteOffsCount { get; set; }

        /// <summary>
        /// A number of cancelled write-offs
        /// </summary>
        public int CancelledWriteOffsCount { get; set; }

        /// <summary>
        /// A number of done write-offs
        /// </summary>
        public int DoneWriteOffsCount { get; set; }

        /// <summary>
        /// A number of new write-offs
        /// </summary>
        public int NewWriteOffsCount { get; set; }

        /// <summary>
        /// Sorting order for orders
        /// </summary>
        public OrderSortBy SortingOrder { get; set; } = OrderSortBy.OrderCreationDate;

        /// <summary>
        /// Orders to be shown
        /// </summary>
        public StockOrderShow ShowingOrders { get; set; } = StockOrderShow.AllOrders;

        /// <summary>
        /// Sorting type for orders
        /// If true - descending sorting, if false - ascending sorting
        /// </summary>
        public bool SortingTypeOrders { get; set; } = false;

        /// <summary>
        /// Sorting type for products
        /// If true - descending sorting, if false - ascending sorting
        /// </summary>
        public bool SortingTypeProducts { get; set; } = false;

        /// <summary>
        /// A sorting type for supplies
        /// If true - descending sorting, if false - ascending sorting
        /// </summary>
        public bool SortingTypeSupplies { get; set; } = false;

        /// <summary>
        /// A sorting type for write-offs
        /// If true - descending sorting, if false - ascending sorting
        /// </summary>
        public bool SortingTypeWriteOffs { get; set; } = false;


        /// <summary>
        /// Sorting order for products
        /// </summary>
        public ProductSortBy ProductSortingOrder { get; set; } = ProductSortBy.ArtNumber;

        /// <summary>
        /// Products to be shown
        /// </summary>
        public ProductShow ShowingProducts { get; set; } = ProductShow.AllProducts;


        /// <summary>
        /// Sorting order for supplies
        /// </summary>
        public SupplySortBy SupplySortingOrder { get; set; } = SupplySortBy.SupplyNumber;

        /// <summary>
        /// Supplies to be shown
        /// </summary>
        public SupplyShow ShowingSupplies { get; set; } = SupplyShow.AllSupplies;


        /// <summary>
        /// Sorting order for write-offd
        /// </summary>
        public WriteOffSortBy WriteOffSortingOrder { get; set; } = WriteOffSortBy.WriteOffNumber;

        /// <summary>
        /// Write-offs to be shown
        /// </summary>
        public WriteOffShow ShowingWriteOffs { get; set; } = WriteOffShow.AllWriteOffs;


        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AppStockViewModel()
        {
            //Initialize all commands for orders

            RejectOrderCommand = new RelayCommand(RejectOrder);
            ApproveOrderCommand = new RelayCommand(ApproveOrder);
            PrintOrderCommand = new RelayCommand(PrintOrder);
            ShipOrderCommand = new RelayCommand(ShipOrder);
            CustomerInfoOrderCommand = new RelayCommand(CustomerInfoOrder);
            InfoOrderCommand = new RelayCommand(InfoOrder);
            InvoiceOrderCommand = new RelayCommand(InvoiceOrder);
            SortOrderCommand = new RelayCommand(SortOrder);


            //Initialize all commands for products

            NewProductCommand = new RelayCommand(NewProduct);
            EditProductCommand = new RelayCommand(EditProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct);
            SupplierInfoProductCommand = new RelayCommand(SupplierInfoProduct);
            OrdersProductCommand = new RelayCommand(OrdersProduct);
            InfoProductCommand = new RelayCommand(InfoProduct);
            SortProductCommand = new RelayCommand(SortProduct);

            //Initialize all commands for supplies

            NewSupplyCommand = new RelayCommand(NewSupply);
            EditSupplyCommand = new RelayCommand(EditSupply);
            DeleteSupplyCommand = new RelayCommand(DeleteSupply);
            SupplierInfoSupplyCommand = new RelayCommand(SupplierInfoSupply);
            ProductsSupplyCommand = new RelayCommand(ProductsSupply);
            InfoSupplyCommand = new RelayCommand(InfoSupply);
            InvoiceSupplyCommand = new RelayCommand(InvoiceSupply);
            PaymentSupplyCommand = new RelayCommand(PaymentSupply);
            SortSupplyCommand = new RelayCommand(SortSupply);


            //Initialize all commands for write-offs

            NewWriteOffCommand = new RelayCommand(NewWriteOff);
            EditWriteOffCommand = new RelayCommand(EditWriteOff);
            DeleteWriteOffCommand = new RelayCommand(DeleteWriteOff);
            ProductsWriteOffCommand = new RelayCommand(ProductsWriteOff);
            InfoWriteOffCommand = new RelayCommand(InfoWriteOff);
            InvoiceWriteOffCommand = new RelayCommand(InvoiceWriteOff);
            SortWriteOffCommand = new RelayCommand(SortWriteOff);
            //Get summary about orders
            GetSummary();
        }
        #endregion

        #region Helpers

        /// <summary>
        /// Gets summary about orders
        /// </summary>
        private void GetSummary()
        {
            //TODO: gets summary about orders
        }

        #endregion

        #region Stock Orders Commands Handlers
        

        /// <summary>
        /// Rejects current order
        /// </summary>
        private void RejectOrder() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Approve currently selected order
        /// </summary>
        private void ApproveOrder()
        {
           throw new NotImplementedException();
        }

        /// <summary>
        /// Print currently selected order
        /// </summary>
        private void PrintOrder()
        {
            throw new NotImplementedException();
        }

       
        /// <summary>
        /// Show info about customer
        /// </summary>
        private void CustomerInfoOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Ship currently selected order
        /// </summary>
        private void ShipOrder()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Show all info about currently selected order
        /// </summary>
        private void InfoOrder()
        {
            //TODO: replace this with actual actions
            var vm = new MessageBoxDialogViewModel()
            {
                Title = "Текущий заказ",
                Message = $"Текущий выбранный заказ: {CurrentOrderNumber}"

            };
            IoC.UI.ShowMessage(vm);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Show invoice for currently selected order
        /// </summary>
        private void InvoiceOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set sorting order 
        /// </summary>
        private void SortOrder()
        {
            //Inverts a current value of SortingType
            SortingTypeOrders ^= true;
        }
        #endregion

        #region Stock Products Commands Handlers


        /// <summary>
        /// Creates a new product
        /// </summary>
        private void NewProduct()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit the currently selected product
        /// </summary>
        private void EditProduct()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows info about the currently selected product
        /// </summary>
        private void InfoProduct()
        {
            //TODO: replace this with actual actions
            var vm = new MessageBoxDialogViewModel()
            {
                Title = "Текущий заказ",
                Message = $"Текущий выбранный товар: {CurrentProductArtNumber}"

            };
            IoC.UI.ShowMessage(vm);
        }


        /// <summary>
        /// Deletes the selected product
        /// </summary>
        private void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows info about the supplier of this product
        /// </summary>
        private void SupplierInfoProduct()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Show all orders that includes this product
        /// </summary>
        private void OrdersProduct()
        {
            
            throw new NotImplementedException();
        }

        

        /// <summary>
        /// Set sorting order 
        /// </summary>
        private void SortProduct()
        {
            //Inverts a current value of SortingType
            SortingTypeProducts ^= true;
        }
        #endregion

        #region Stock Supplies Commands Handlers


        /// <summary>
        /// Creates a new supply
        /// </summary>
        private void NewSupply()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edits the currently selected supply
        /// </summary>
        private void EditSupply()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the currently selected supply
        /// </summary>
        private void DeleteSupply()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Shows the info about supplier of this supply
        /// </summary>
        private void SupplierInfoSupply()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows info about products this supply provides
        /// </summary>
        private void ProductsSupply()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Show all info about current supply
        /// </summary>
        private void InfoSupply()
        {

            //TODO: replace this with actual actions
            var vm = new MessageBoxDialogViewModel()
            {
                Title = "Текущая поставка",
                Message = $"Текущая выбранная поставка: {CurrentSupplyNumber}"

            };
            IoC.UI.ShowMessage(vm);
        }



        /// <summary>
        /// Sets a sorting type for supplies
        /// </summary>
        private void SortSupply()
        {
            //Inverts a current value of SortingType
            SortingTypeSupplies ^= true;
        }

        /// <summary>
        /// Shows an invoice for this supply
        /// </summary>
        private void InvoiceSupply()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shows the payment details for current supply
        /// </summary>
        private void PaymentSupply()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Stock Write-Offs Commands Handlers


        /// <summary>
        /// Creates a new write-off
        /// </summary>
        private void NewWriteOff()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edits the currently selected write-off
        /// </summary>
        private void EditWriteOff()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the currently selected write-off
        /// </summary>
        private void DeleteWriteOff()
        {
            throw new NotImplementedException();
        }


       
        /// <summary>
        /// Shows info about products included to this write-off
        /// </summary>
        private void ProductsWriteOff()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Show all info about current write-off
        /// </summary>
        private void InfoWriteOff()
        {

            //TODO: replace this with actual actions
            var vm = new MessageBoxDialogViewModel()
            {
                Title = "Текущее списание",
                Message = $"Текущее выбранное списание: {CurrentWriteOffNumber}"

            };
            IoC.UI.ShowMessage(vm);
        }



        /// <summary>
        /// Setts a type of sorting for write-offs
        /// </summary>
        private void SortWriteOff()
        {
            //Inverts a current value of SortingType
            SortingTypeWriteOffs ^= true;
        }

        /// <summary>
        /// Shows an invoice for this write-off
        /// </summary>
        private void InvoiceWriteOff()
        {
            throw new NotImplementedException();
        }

        
        #endregion
    }

}
