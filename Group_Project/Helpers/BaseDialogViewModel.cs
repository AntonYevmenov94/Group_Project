
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// Базовый класс для ViewModel'ей диалоговых окон.
    /// </summary>
    public class BaseDialogViewModel : BaseViewModel
    {
        #region Public properties

        public string DialogWindowTitle { get; set; }
        public Action OnConfirm { get; set; } = new Action(() => {});
        public Action OnDismiss { get; set; } = new Action(() => { });
        #endregion


        #region Constructor

        public BaseDialogViewModel(
            IAuthService accountService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder) 
            : base(accountService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            
        }
        #endregion

    }
}
