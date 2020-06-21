using System;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Group_Project
{
    /// <summary>
    /// Базовый класс для ViewModel'ей диалоговых окон.
    /// </summary>
    public class BaseDialogViewModel : BaseViewModel
    {
        #region Public properties

        public string DialogWindowTitle { get; set; }
        public Action OnConfirm { get; set; } = new Action(() => { });
        public Action OnDismiss { get; set; } = new Action(() => { });
        #endregion


        #region Constructor

        public BaseDialogViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
        }
        #endregion
    }
}
