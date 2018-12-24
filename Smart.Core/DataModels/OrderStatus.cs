using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{
    public enum OrderStatus
    {
        NewOrder,
        ManagerProcessing,
        StockProcessing,
        StockApproved,
        StockRejected,
        StockDepartured,
        TransferedToSC,
        Delivering,
        Delivered,
        Done,
        Closed,
        Cancelled
    }
}
