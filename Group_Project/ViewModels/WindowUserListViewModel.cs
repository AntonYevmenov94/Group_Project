using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления предназначенная для работы со списком аккаунтов пользователей программы.
    /// Привязывается к окну <see cref="Views.WindowUserList"/>
    /// </summary>
    public class WindowUserListViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }
        
        public WindowUserListViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            User user)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            var db = dbContextProvider.GetDbContext();
            this.SelectedUser = user;
            db.Users.Load();
            Users = new ObservableCollection<User>();
            Users = db.Users.Local; 
        }


        public RelayCommand addUserCommand;
        public RelayCommand AddUserCommand
        {
            get
            {
                return addUserCommand ?? (addUserCommand = new RelayCommand(obj =>
                {

                }));
            }
        }

        public RelayCommand editUserCommand;
        public RelayCommand EditUserCommand
        {
            get
            {
                return addUserCommand ?? (addUserCommand = new RelayCommand(obj =>
                {

                }));
            }
        }
    }
}
