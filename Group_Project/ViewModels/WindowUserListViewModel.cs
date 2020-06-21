using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления предназначенная для работы со списком аккаунтов пользователей программы.
    /// Привязывается к окну <see cref="Views.WindowUserList"/>
    /// </summary>
    public class WindowUserListViewModel : BaseViewModel
    {
        private UserViewModel.Factory userVmFactory;
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }
        
        public WindowUserListViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            UserViewModel.Factory userVmFactory)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            this.userVmFactory = userVmFactory;
            var db = dbContextProvider.GetDbContext();
            db.Users.Load();
            Users = db.Users.Local;
           

        }


        public RelayCommand addUserCommand;
        public RelayCommand AddUserCommand
        {
            get
            {
                return addUserCommand ?? (addUserCommand = new RelayCommand(obj =>
                {
                    User user = new User();
                    var vm = userVmFactory.Invoke(user);
                    dialogService.ShowModal(vm);

                    RefreshData();
                  
                }));
            }
        }


        public RelayCommand editUserCommand;
        public RelayCommand EditUserCommand
        {
            get 
            {
                return editUserCommand ?? (editUserCommand = new RelayCommand(obj =>
                {
                    var editUser = (User)obj;
                    var userVm = userVmFactory.Invoke(editUser);
                    dialogService.ShowModal(userVm);
                    RefreshData();
                }));
            }
        }


        
        public RelayCommand deleteUserCommand;
        public RelayCommand DeleteUserCommand
        {
            get
            {
                return deleteUserCommand ?? (deleteUserCommand = new RelayCommand(obj =>
                {
                    var deleteUser = (User)obj;
                    var db = dbContextProvider.GetDbContext();

                    if (deleteUser != null)
                    {
                        //if (MessageBox.Show("Вы действительно хотите удалить пользователя")
                        //==dialogService.Show(userVm)
                        //db.Entry(SelectedUser).State = EntityState.Deleted;
                       
                        db.Users.Remove(deleteUser);
                        db.SaveChanges();
                       
                    }
                    MessageBox.Show($"Пользователь удален {deleteUser.Login}");
                    RefreshData();

                }));
            }

        }

        private void RefreshData()
        {
            var db = dbContextProvider.GetDbContext();
            db.Users.Load();
            Users = db.Users.Local;
        }

    }
}
