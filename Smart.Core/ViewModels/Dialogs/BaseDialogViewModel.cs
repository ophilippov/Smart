﻿using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Smart.Core
{
    /// <summary>
    /// A base view model for any dialogs    
    /// </summary>
    
    public class BaseDialogViewModel : BaseViewModel
    {
        /// <summary>
        /// The title of the dialog
        /// </summary>
        public string Title { get; set; }
        
       
    }
}