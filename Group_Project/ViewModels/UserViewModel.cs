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
            SelectedUser = db.Users.Find(user.Id);
            // не біл найжен в БД
            if (SelectedUser == null)
                SelectedUser = user;
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
                    // если id == 0 сущность еще не добавлялась в БД => нужно сначала добавить
                    if (SelectedUser.Id == 0)
                    {
                        dbContextProvider.GetDbContext().Users.Add(SelectedUser);
                        infoWindow();
                        //logger.LogAction($"Добавлен пользователь {SelectedUser.Login}");
                    }
                    else
                    {
                        infoWindow();
                        //logger.LogAction($"Изменен пользователь ID {SelectedUser.Id}");
                    }
                    
                   
                    dbContextProvider.GetDbContext().SaveChanges();
                    
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
                                      
                }));
            }
        }
      
    }
}
