using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления экземпляра сущности <see cref="User"/>.
    /// Привязывается к окну <see cref="Views.WindowUserEdit"/>
    /// </summary>
    public class UserViewModel : BaseDialogViewModel
    {
        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate UserViewModel Factory(User user);

        public User SelectedUser { get; set;}
        public ObservableCollection<Role> Roles { get; set; }

      
        public UserViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            User user)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            var db = dbContextProvider.GetDbContext();
            //this.SelectedUser = user;
            db.Roles.Load();
            //Roles = new ObservableCollection<Role>();
            Roles = db.Roles.Local;
        }

        public RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(obj =>
                {
                    infoWindow();
                    Person person = new Person();
                    dbContextProvider.GetDbContext().SaveChanges();
                    logger.LogAction(" сахранен пользователь", person);
                }));
            }
        }
        private static void infoWindow()
        {
            MessageBox.Show("Пользователь сохранен!");
        }
        public RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new RelayCommand(obj =>
                {

                    Close();

                }));
            }
        }
        private void Close()
        {
            this.Close();
        }

    }
}
