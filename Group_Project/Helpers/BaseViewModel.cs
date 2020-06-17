using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// Базовый класс для ViewModel'ей. 
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected ILogger logger;
        protected ILogMessageBuilder logMessageBuilder;
        protected IDialogService dialogService;
        protected IDbContextProvider dbContextProvider;
        public IAuthService accountService;

        public BaseViewModel(
            IAuthService accountService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder)
        {
            this.accountService = accountService;
            this.dbContextProvider = dbContextProvider;
            this.dialogService = dialogService;
            this.logger = logger;
            this.logMessageBuilder = logMessageBuilder;
        }
    }
}
