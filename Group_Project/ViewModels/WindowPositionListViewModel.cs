using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления списка должностей. Привязывается к окну WindowGenericList, которое делит с
    /// WindowDepartmentListViewModel, WindowDisciplineListViewModel, WindowTechListViewModel 
    /// </summary>
    public class WindowPositionListViewModel : BaseViewModel
    {
        // название окна (можно установить в конструкторе)
        public string WindowTitle { get; set; }
        // название списка элементов (текст label над listbox'ом) (можно установить в конструкторе)
        public string ListTitle { get; set; }
        // коллекция элементов, которые отображаются в списке
        public ObservableCollection<Position> ListItems { get; set; }
        public Department SelectedPosition { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public WindowPositionListViewModel(
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
