using System.Collections.ObjectModel;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления списка предметов. Привязывается к окну WindowGenericList, которое делит с
    /// WindowDepartmentListViewModel, WindowPositionListViewModel, WindowTechListViewModel 
    /// </summary>
    public class WindowDisciplineListViewModel : BaseViewModel
    {
        // название окна (можно установить в конструкторе)
        public string WindowTitle { get; set; }
        // название списка элементов (текст label над listbox'ом) (можно установить в конструкторе)
        public string ListTitle { get; set; }
        // коллекция элементов, которые отображаются в списке
        public ObservableCollection<Discipline> ListItems { get; set; }

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
