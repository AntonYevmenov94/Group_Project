using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления экземпляра сущности <see cref="Position"/>.
    /// Привязывается к окну <see cref="Views.WindowPositionEdit"/>
    /// </summary>
    public class PositionViewModel : BaseDialogViewModel
    {
        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate PositionViewModel Factory(Position position);
        public Department SelectedDepartment { get; set;}
        public ObservableCollection<Department> Departments { get; set; }
        public Position SelectedPosition { get; set; }
        public PositionViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            Position position)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            var db = dbContextProvider.GetDbContext();
            db.Departments.Load();
            Departments = db.Departments.Local;
            //db.Positions.Load();
            //Positions = db.Positions.Local;
            SelectedPosition = db.Positions.Find(position.Id);
            if (SelectedPosition!= null)
            {
                SelectedPosition = position;
            }
        }


        public RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(obj =>
                {
                    infoWindow();
                    dbContextProvider.GetDbContext().Positions.Add(SelectedPosition);
                    dbContextProvider.GetDbContext().SaveChanges();

                }));
            }
        }
        private static void infoWindow()
        {
            MessageBox.Show(" Должность сохранена!");
        }
        public RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new RelayCommand(obj =>
                {

                }));
            }
        }
    }
}
