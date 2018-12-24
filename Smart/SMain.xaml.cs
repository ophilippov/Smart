using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Smart
{
    /// <summary>
    /// Логика взаимодействия для SMain.xaml
    /// </summary>
    public partial class SMain : Window
    {
        public SMain()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);
            
        }

        private void SegnoMain_Activated(object sender, EventArgs e)
        {
            //Hide overlay if we are focused
            (DataContext as WindowViewModel).DimmableOverlayVisible = false;
        }

        private void SegnoMain_Deactivated(object sender, EventArgs e)
        {
            //Show overlay if we lose focus
            (DataContext as WindowViewModel).DimmableOverlayVisible = true;
        }
    }
}
