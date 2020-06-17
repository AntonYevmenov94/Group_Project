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
    /// Логика взаимодействия для Positions.xaml
    /// </summary>
    public partial class WindowPositions : Window
    {
        public WindowPositions()
        {
            InitializeComponent();
        }

        // TODO Удалить. За эти действия должна отвечать ViewModel
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowADDPosition addForm = new WindowADDPosition();
            addForm.Show();
        }
    }
}
