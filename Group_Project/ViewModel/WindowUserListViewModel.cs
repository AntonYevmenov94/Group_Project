using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Group_Project.Utilities;
using Group_Project.Helper;
using Group_Project.Interfaces;

namespace Group_Project.ViewModel
{
     public class WindowUserListViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }

        public ICommand AddUserCommand { get; private set; }
        public ICommand EditUserCommand { get; set; }


        public WindowUserListViewModel(
            IAuthService accountService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder)
            : base(accountService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            
        }
              

    }
}
