using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Smart.Core
{
    /// <summary>
    /// A base view model that fires PropertyChanged events as needed
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged (string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command helpers

        /// <summary>
        /// Runs a command if the updating flag isn`t set
        /// Once the action is finished if it was run, then the flag is reset to false
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag defines if the command is already running</param>
        /// <param name="action">The action to run if the command is not alresy running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {

            //Check if the flag property is true (meaning the function is alredy running 
            if (updatingFlag.GetPropertyValue()) return;

            //Set the updating flag to true to indicate we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                //Run the passed in action
                await action();
            }
            finally
            {
                //Set the updating flag back false now it`s finished
                updatingFlag.SetPropertyValue(false);
            }

        }
        #endregion
    }
}