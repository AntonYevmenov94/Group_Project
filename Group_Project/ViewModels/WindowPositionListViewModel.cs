using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления списка технологий. Привязывается к окну <see cref="Views.WindowGenericList"/>,
    /// которое делит с моделями-представлений <see cref="WindowDepartmentListViewModel"/>, 
    /// <see cref="WindowDisciplineListViewModel"/>, <see cref="WindowTechListViewModel "/>
    /// </summary>
    public class WindowPositionListViewModel : BaseViewModel
    {
        // название окна (можно установить в конструкторе)
        public string WindowTitle { get; set; }
        // название списка элементов (текст label над listbox'ом) (можно установить в конструкторе)
        public string ListTitle { get; set; }
        // коллекция элементов, которые отображаются в списке
        public ObservableCollection<Position> Positions { get; set; }
        // выделенный элемент списка
        public Position SelectedPosition { get; set; }


        #region Commands

        //public ICommand CmdAddListItem { get; set; }
        //public ICommand CmdEditListItem { get; set; }
        //public ICommand CmdDeleteListItem { get; set; }
        #endregion


        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate WindowPositionListViewModel Factory();

        public PositionViewModel.Factory positionVmFactory;

        public WindowPositionListViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            PositionViewModel.Factory positionVmFactory)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            var db = dbContextProvider.GetDbContext();
            this.positionVmFactory = positionVmFactory;
            db.Positions.Load();
            Positions = db.Positions.Local;

        }

        public RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    Position position = new Position();
                    var vm = positionVmFactory.Invoke(position);
                    dialogService.ShowModal(vm);
                    

                }));
            }
        }

        public RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get 
            {
                return editCommand ?? (editCommand = new RelayCommand(obj =>
                {
                    
                    var editPosition = (Position)obj;
                    var posVm = positionVmFactory.Invoke(editPosition);
                    dialogService.ShowModal(posVm);
                  

                }));
            }
        }

        public RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
                {
                    var delSelectPosition = (Position)obj;
                    var db = dbContextProvider.GetDbContext();
                    if (delSelectPosition!=null)
                    {
                        db.Positions.Remove(delSelectPosition);
                        db.SaveChanges();
                    }
                }));
            }
        }
    }
}
