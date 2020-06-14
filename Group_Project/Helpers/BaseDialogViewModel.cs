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
    class BaseDialogViewModel : BaseViewModel
    {
        #region Public properties

        public string DialogWindowTitle { get; set; }
        public Action OnConfirm { get; set; } = new Action(() => {});
        public Action OnDismiss { get; set; } = new Action(() => { });
        #endregion


        #region Constructor

        public BaseDialogViewModel(
            IDbContextProvider dbContextProvider, 
            IDialogService dialogService) 
            : base(dbContextProvider, dialogService)
        {
            
        }
        #endregion


        #region Commands

        /// <summary>
        /// Подтвердить выполнение действия в диалоге (обычно кнопки ОК, Confirm, Подтвердить)
        /// </summary>
        private RelayCommand confirmCmd;
        public RelayCommand ConfirmCmd
        {
            get => confirmCmd ?? (confirmCmd = new RelayCommand(
                (obj) => {
                    OnConfirm.Invoke();
                },
                null));
        }

        /// <summary>
        /// Отменить выполнение действия в диалоге (обычно кнопки No, Нет)
        /// </summary>
        private RelayCommand dismissCmd;
        public RelayCommand DissmissCmd
        {
            get => dismissCmd ?? (dismissCmd = new RelayCommand(
                (obj) => {
                    OnDismiss.Invoke();
                },
                null));
        }
        #endregion
    }
}
