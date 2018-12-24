using Smart.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Smart
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup so we load our IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //Let the base application to what it needs
            base.OnStartup(e);

            //Setup this Application
            ApplicationSetup();

            //Log it
            
            IoC.Logger.LogOutputLevel = LogOutputLevel.Debug;
            
            IoC.Logger.Log("Application starting...", LogLevel.Informative);


            //Show the MainWindow (SMain in this case)
            Current.MainWindow = new SMain();
            Current.MainWindow.Show();
        
        }

        /// <summary>
        /// Configures uor application ready to use
        /// </summary>
        private void ApplicationSetup()
        {
            //Setup our IoC container
            IoC.Setup();

            //Bind a UI manager class, that implements a IUIManager Interface
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            //Bind a Logger
            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory());
        }
    }
}
