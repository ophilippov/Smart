using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.Core
{

    /// <summary>
    /// The class that provides design data which <see cref="WriteOffsListControl"> can display
    /// </summary>
    public class WriteOffsListDesignModel : WriteOffsViewModel
    {

        #region Singleton

        /// <summary>
        /// A single static instance of this class
        /// </summary>
        public static WriteOffsListDesignModel Instance => new WriteOffsListDesignModel();
        #endregion


        #region Public Constructor
        /// <summary>
        /// The public constructor
        /// </summary>
        public WriteOffsListDesignModel()
        {
            WriteOffs = new List<WriteOffsListItemViewModel>
            {
                new WriteOffsListItemViewModel
                {
                    WriteOffNumber = "123562221",
                    Price = 250.1d,
                    Status = WriteOffStatus.NewWriteOff,
                    CreationDate = DateTime.UtcNow.Date,
                    ItemsCount = 25
                },
                new WriteOffsListItemViewModel
                {
                    WriteOffNumber = "123562222",
                    Price = 26.0d,
                    Status = WriteOffStatus.Cancelled,
                    CreationDate = DateTime.UtcNow.Date,
                    ItemsCount = 5
                },
                new WriteOffsListItemViewModel
                {
                    WriteOffNumber = "123562223",
                    Price = 985.79d,
                    Status = WriteOffStatus.Done,
                    CreationDate = DateTime.UtcNow.Date,
                    ItemsCount = 120
                },
                new WriteOffsListItemViewModel
                {
                    WriteOffNumber = "123562224",
                    Price = 10.25d,
                    Status = WriteOffStatus.Done,
                    CreationDate = DateTime.UtcNow.Date,
                    ItemsCount = 2
                }

            };   
        }
        #endregion



    }
}
