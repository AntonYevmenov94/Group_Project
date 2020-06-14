using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// Базовый класс для ViewModel'ей. 
    /// </summary>
    public class BaseViewModel
    {
        private ILogger logger;
        private IDialogService dialogService;
        public IDbContextProvider dbContextProvider;
        public IAccountService accountService;


        public BaseViewModel(
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            IAccountService accountService)
        {
            this.dbContextProvider = dbContextProvider;
            this.dialogService = dialogService;
            this.logger = logger;
            this.accountService = accountService;
        }
    }
}
