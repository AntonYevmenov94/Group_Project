using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
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
        private DisciplineViewModel.Factory disciplineVmFactory;

        // название окна (можно установить в конструкторе)
        public string WindowTitle { get; set; } = "Предметы";
        // название списка элементов (текст label над listbox'ом) (можно установить в конструкторе)
        public string ListTitle { get; set; } = "Предметы";
        // коллекция элементов, которые отображаются в списке
        public ObservableCollection<Discipline> ListItems { get; set; }
        // выделенный элемент списка
        public Discipline SelectedListItem { get; set; }


        #region Commands

        public ICommand CmdAddListItem { get; set; }
        public ICommand CmdEditListItem { get; set; }
        public ICommand CmdDeleteListItem { get; set; }
        #endregion


        #region Constructor
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
            ILogMessageBuilder logMessageBuilder,
            DisciplineViewModel.Factory disciplineVmFactory)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            this.disciplineVmFactory = disciplineVmFactory;
            LoadDisciplinesFromDb(dbContextProvider);

            CmdAddListItem = new RelayCommand(new Action<object>(AddListItem));
            CmdEditListItem = new RelayCommand(
                new Action<object>(EditListItem),
                (obj) => { return SelectedListItem != null; });
            CmdDeleteListItem = new RelayCommand(
                new Action<object>(DeleteListItem),
                (obj) => { return SelectedListItem != null; });
        }
        #endregion


        #region Private methods

        private void LoadDisciplinesFromDb(IDbContextProvider dbContextProvider)
        {
            dbContextProvider.Refresh();
            var db = dbContextProvider.GetDbContext();
            db.Disciplines.Load();
            ListItems = db.Disciplines.Local;
        }
        #endregion


        #region Commands implementation

        private void AddListItem(object obj)
        {
            var winVm = disciplineVmFactory.Invoke(new Discipline());
            var dlgRes = dialogService.ShowModal(winVm);

            if (dlgRes == true)
            {
                LoadDisciplinesFromDb(dbContextProvider);
            }
        }

        private void EditListItem(object obj)
        {
            if (SelectedListItem == null)
                return;

            var winVm = disciplineVmFactory.Invoke(SelectedListItem);
            var dlgRes = dialogService.ShowModal(winVm);
            var selectedItemId = SelectedListItem.Id;

            if (dlgRes == true)
            {
                LoadDisciplinesFromDb(dbContextProvider);
                SelectedListItem = ListItems.FirstOrDefault(i => i.Id == selectedItemId);
            }
        }

        private void DeleteListItem(object obj)
        {
            if (SelectedListItem == null)
                return;

            var db = dbContextProvider.GetDbContext();
            db.Disciplines.Remove(SelectedListItem);
            db.SaveChanges();

            LoadDisciplinesFromDb(dbContextProvider);
        }
        #endregion
    }
}
