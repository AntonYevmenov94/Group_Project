using System.Windows;

namespace Group_Project.Views
{
    /// <summary>
    /// Interaction logic for WindowDiscipline.xaml
    /// </summary>
    public partial class WindowDisciplineEdit : Window
    {
        public WindowDisciplineEdit()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
