using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления экземпляра сущности <see cref="Vacancy"/>.
    /// Привязывается к окну <see cref="Views.WindowVacancyEdit"/>
    /// </summary>
    public class VacancyViewModel : BaseDialogViewModel
    {
        #region Public properties 

        public Vacancy InternalVacancy { get; set; }
        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Discipline> Disciplines { get; set; }
        public ObservableCollection<Technology> Technologies { get; set; }
        #endregion


        #region Commands

        public ICommand ArchiveVacancyCommand { get; set; }
        public ICommand AddDisciplineCommand { get; set; }
        public ICommand BackVacancyCommand { get; set; }
        public ICommand NResponseCommand { get; set; }
        public ICommand CreateResponseCommand { get; set; }
        #endregion


        #region Constructor

        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate VacancyViewModel Factory(Vacancy vacancy);


        public VacancyViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            Vacancy vacancy)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
        }

        #endregion

    }
}
