using System.Collections.ObjectModel;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления списка отделов. Привязывается к окну WindowGenericList, которое делит с
    /// WindowDisciplineListViewModel, WindowPositionListViewModel, WindowTechListViewModel 
    /// </summary>
    public class WindowDepartmentListViewModel : BaseViewModel
    {
        // название окна (можно установить в конструкторе)
        public string WindowTitle { get; set; }
        // название списка элементов (текст label над listbox'ом) (можно установить в конструкторе)
        public string ListTitle { get; set; }
        // коллекция элементов, которые отображаются в списке
        public ObservableCollection<Department> ListItems { get; set; }

        public WindowDepartmentListViewModel(
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
