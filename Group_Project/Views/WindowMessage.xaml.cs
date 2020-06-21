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

namespace Group_Project.Views
{
    /// <summary>
    /// Interaction logic for WindowMessage.xaml
    /// </summary>
    public partial class WindowMessage : Window
    {
        public WindowMessage()
        {
            InitializeComponent();
        }

        private void OkBtnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
