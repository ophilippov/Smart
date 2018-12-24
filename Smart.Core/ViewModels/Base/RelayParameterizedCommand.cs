using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Smart.Core

{

    /// <summary>
    /// A basic command to run an Action
    /// </summary>
    public class RelayParameterizedCommand : ICommand
    {
        #region Public members

        /// <summary>
        /// The action to run
        /// </summary>
        private Action<object> mAction;
        #endregion

        #region Public events

        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e)=> { };

        #endregion

        #region Constructor

        /// <summary>
        /// The default constructor
        /// </summary>
        public RelayParameterizedCommand(Action<object> action)
        {
            mAction = action;
        }
        #endregion

        #region Command Methods
        /// <summary>
        /// A relay commnad can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }


        /// <summary>
        /// Executes the commands Action
        /// </summary>
        /// <param name="parameter"></param>

        public void Execute(object parameter)
        {
            mAction(parameter);
        }
        #endregion


    }
}
