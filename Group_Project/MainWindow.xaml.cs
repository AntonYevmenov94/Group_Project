using Group_Project.ViewModels;
using System.Windows;

namespace Group_Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ShellViewModel shellViewModel)
        {
            InitializeComponent();

            this.DataContext = shellViewModel;
        }
    }
}