
namespace Smart.Core
{
    /// <summary>
    /// Orders to be shown
    /// </summary>
    public enum OrderShow
    {
        AllOrders = 0,
        ActiveOrders = 1,
        NewOrders = 2,
        ManagerProcessingOrders = 3,
        StockProcessingOrders = 4,
        StockApprovedOrders = 5,
        StockRejectedOrders = 6,
        StockShippedOrders = 7,
        TransferedToSCOrders = 8,
        DeliveringOrders = 9,
        DeliveredOrders = 10,
        DoneOrders = 11,
        CancelledOrders = 12,
        ClosedOrders = 13,
        WaitingForPaymentOrders = 14,
        PaidOrders = 15,
        PartPaidOrders = 16,
        PaymentOverdueOrders = 17,
        PayBackOrders = 18
    }

    /// <summary>
    /// Orders to be shown (Stock)
    /// </summary>
    public enum StockOrderShow
    {
        /// <summary>
        /// All orders that is available to show
        /// </summary>
        AllOrders = 0,

        /// <summary>
        /// New orders to show
        /// </summary>
        ProcessingOrders = 1,
        
        /// <summary>
        /// Is being packing
        /// </summary>
        ApprovedOrders = 2,
        RejectedOrders = 3,

        /// <summary>
        /// Orders, that is shipped from the stock
        /// </summary>
        ShippedOrders = 4,

        /// <summary>
        /// Orders, that is transfered to the SC 
        /// </summary>
        TransferedToSCOrders = 5
        
    }
}
