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
        /// Зарегестрировать отношение модели-представления к окну.
        /// </summary>
        /// <param name="viewModel">Тип модели-представления</param>
        /// <param name="window">Тип окна</param>
        void Register(Type viewModel, Type window);
        
        /// <summary>
        /// Открыть окно.
        /// </summary>
        /// <param name="onConfirm">Действие, которое должно быть выполнено, если пользователь нажмет Save/Ok/Confirm</param>
        /// <param name="onDismiss">Действие, которое должно быть выполнено, если пользователь нажмет No/Cancel/Отмена</param>
        void Show(BaseDialogViewModel dialogVm, Action onConfirm = null, Action onDismiss = null);

        /// <summary>
        /// Открыть модальное окно.
        /// </summary>
        /// <param name="onConfirm">Действие, которое должно быть выполнено, если пользователь нажмет Save/Ok/Confirm</param>
        /// <param name="onDismiss">Действие, которое должно быть выполнено, если пользователь нажмет No/Cancel/Отмена</param>
        /// <returns>Результат диалога.</returns>
        bool? ShowModal(BaseDialogViewModel dialogVm, Action onConfirm = null, Action onDismiss = null);



        // Диалоги открытия и сохранения вынесены в отдельные методы поскольку нужно работать
        // c родными Windows диалогами.

        /// <summary>
        /// Показать диалог сохранения файла.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        string SaveFileDialog();

        /// <summary>
        /// Показать диалог открытия файла.
        /// </summary>
        /// <returns>Путь к файлу.</returns>
        string OpenFileDialog();
    }
}
