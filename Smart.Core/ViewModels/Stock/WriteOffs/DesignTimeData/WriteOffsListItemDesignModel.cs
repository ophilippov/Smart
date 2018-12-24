using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core { 

    /// <summary>
    /// The class that provides design data which <see cref="WriteOffsListItemControl"> can display
    /// </summary>
    public class WriteOffsListItemDesignModel: WriteOffsListItemViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static WriteOffsListItemDesignModel Instance => new WriteOffsListItemDesignModel();
        #endregion

        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public WriteOffsListItemDesignModel()
        {
            WriteOffNumber = "123562221";
            Price = 250.1d;
            Status = WriteOffStatus.NewWriteOff;
            CreationDate = DateTime.UtcNow.Date;
            ItemsCount = 25;

        }
        #endregion



    }
}
