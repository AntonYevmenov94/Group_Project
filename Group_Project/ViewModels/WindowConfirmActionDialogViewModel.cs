using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    public class WindowConfirmActionDialogViewModel : BaseDialogViewModel
    {
        public string MessageText { get; set; }
        public bool? DialogResult { get; private set; }

        public ICommand CmdConfirm { get; set; }
        public ICommand CmdDismiss { get; set; }

        #region Constructor

        public delegate WindowConfirmActionDialogViewModel Factory(string messageText);

        public WindowConfirmActionDialogViewModel(
            IAuthService authService, 
            IDbContextProvider dbContextProvider, 
            IDialogService dialogService, 
            ILogger logger, 
            ILogMessageBuilder logMessageBuilder,
            string messageText) 
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            MessageText = messageText;

            CmdConfirm = new RelayCommand(new Action<object>(DialogConfirm));
            CmdDismiss = new RelayCommand(new Action<object>(DialogDismiss));
        }
        #endregion


        #region Command implementation

        private void DialogConfirm(object obj = null)
        {
            DialogResult = true;
            OnConfirm.Invoke();
        }

        private void DialogDismiss(object obj = null)
        {
            DialogResult = false;
            OnDismiss.Invoke();
        }
        #endregion

    }
}
