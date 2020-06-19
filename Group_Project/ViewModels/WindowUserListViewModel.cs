using System.Collections.ObjectModel;
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

        public ICommand AddUserCommand { get; private set; }
        public ICommand EditUserCommand { get; set; }

        public WindowUserListViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
        }
    }
}
