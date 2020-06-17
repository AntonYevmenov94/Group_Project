using Group_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Helper
{
    /// <summary>
    /// Базовый класс для ViewModel'ей. 
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ILogger logger;
        private IDialogService dialogService;
        public IDbContextProvider dbContextProvider;
        public IAuthService accountService;

        public BaseViewModel(
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            IAuthService accountService)
        {
            this.dbContextProvider = dbContextProvider;
            this.dialogService = dialogService;
            this.logger = logger;
            this.accountService = accountService;
        }

        public BaseViewModel(IDbContextProvider dbContextProvider, IDialogService dialogService)
        {
            this.dbContextProvider = dbContextProvider;
            this.dialogService = dialogService;
        }
    }
}
