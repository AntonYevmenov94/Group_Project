using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.ViewModels
{
    public class WindowTechListViewModel : BaseViewModel
    {
        public WindowTechListViewModel(
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
