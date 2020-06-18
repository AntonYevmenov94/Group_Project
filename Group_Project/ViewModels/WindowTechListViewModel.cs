using System.Collections.ObjectModel;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления списка технологий. Привязывается к окну WindowGenericList, которое делит с
    /// WindowDepartmentListViewModel, WindowDisciplineListViewModel, WindowPositionListViewModel 
    /// </summary>
    public class WindowTechListViewModel : BaseViewModel
    {
        // название окна (можно установить в конструкторе)
        public string WindowTitle { get; set; }
        // название списка элементов (текст label над listbox'ом) (можно установить в конструкторе)
        public string ListTitle { get; set; }
        // коллекция элементов, которые отображаются в списке
        public ObservableCollection<Technology> ListItems { get; set; }

        public WindowTechListViewModel(
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
