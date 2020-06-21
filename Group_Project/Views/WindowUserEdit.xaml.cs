using System.Windows;

namespace Group_Project.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowUserEdit.xaml
    /// </summary>
    public partial class WindowUserEdit : Window
    {
        public WindowUserEdit()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
                
    }
}
