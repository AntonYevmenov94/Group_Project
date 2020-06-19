using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления списка технологий. Привязывается к окну <see cref="Views.WindowGenericList"/>,
    /// которое делит с моделями-представлений <see cref="WindowDepartmentListViewModel"/>, 
    /// <see cref="WindowTechListViewModel"/>, <see cref="WindowPositionListViewModel "/>
    /// </summary>
    public class WindowDisciplineListViewModel : BaseViewModel
    {
        // название окна (можно установить в конструкторе)
        public string WindowTitle { get; set; }
        // название списка элементов (текст label над listbox'ом) (можно установить в конструкторе)
        public string ListTitle { get; set; }
        // коллекция элементов, которые отображаются в списке
        public ObservableCollection<Discipline> ListItems { get; set; }
        // выделенный элемент списка
        public Discipline SelectedListItem { get; set; }


        #region Commands

        public ICommand CmdAddListItem { get; set; }
        public ICommand CmdEditListItem { get; set; }
        public ICommand CmdDeleteListItem { get; set; }
        #endregion


        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate WindowDisciplineListViewModel Factory();

        public WindowDisciplineListViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
        }
    }
}
