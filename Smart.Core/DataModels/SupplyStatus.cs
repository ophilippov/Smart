using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{
    /// <summary>
    /// The status of an Supply
    /// </summary>
    public enum SupplyStatus
    {
        NewSupply,
        Waiting,
        Done,
        Cancelled
    }
}
