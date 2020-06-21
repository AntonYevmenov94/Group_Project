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
    /// Interaction logic for WindowConfirmActionDialog.xaml
    /// </summary>
    public partial class WindowConfirmActionDialog : Window
    {
        public WindowConfirmActionDialog()
        {
            InitializeComponent();
        }

        private void OkBtnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
