using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{
    public enum PaymentStatus
    {

        WaitingForPayment,
        Paid,
        PaidForPart,
        Overdue,
        ReturningMoney

    }
}
