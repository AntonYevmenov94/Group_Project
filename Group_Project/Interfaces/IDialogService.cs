using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    /// <summary>
    /// Представляет прослойку, отделяющую логику программы от реализации интерфейса.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Открыть окно.
        /// </summary>
        /// <param name="onConfirm">Действие, которое должно быть выполнено, если пользователь нажмет Save/Ok/Confirm</param>
        /// <param name="onDismiss">Действие, которое должно быть выполнено, если пользователь нажмет No/Cancel/Отмена</param>
        void Show(BaseViewModel dialogVm, Action onConfirm, Action onDismiss);

        /// <summary>
        /// Открыть модальное окно.
        /// </summary>
        /// <param name="onConfirm">Действие, которое должно быть выполнено, если пользователь нажмет Save/Ok/Confirm</param>
        /// <param name="onDismiss">Действие, которое должно быть выполнено, если пользователь нажмет No/Cancel/Отмена</param>
        void ShowModal(BaseViewModel dialogVm, Action onConfirm, Action onDismiss);



        // Диалоги открытия и сохранения вынесены в отдельные методы поскольку нужно работать
        // c родными Windows диалогами.

        /// <summary>
        /// Показать диалог сохранения файла.
        /// </summary>
        /// <param name="onConfirm">Действие, которое должно быть выполнено, если пользователь нажмет Save/Ok/Confirm</param>
        /// <param name="onDismiss">Действие, которое должно быть выполнено, если пользователь нажмет No/Cancel/Отмена</param>
        void SaveFileDialog(Action onConfirm = null, Action onDismiss = null);

        /// <summary>
        /// Показать диалог открытия файла.
        /// </summary>
        /// <param name="onConfirm">Действие, которое должно быть выполнено, если пользователь нажмет Save/Ok/Confirm</param>
        /// <param name="onDismiss">Действие, которое должно быть выполнено, если пользователь нажмет No/Cancel/Отмена</param>
        void OpenFileDialog(Action onConfirm = null, Action onDismiss = null);
    }
}
