using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
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
        private VacancyViewModel.Factory VacancyVmFactory; 

        public Vacancy InternalVacancy { get; set; }
        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Discipline> Disciplines { get; set; }
        public ObservableCollection<Technology> Technologies { get; set; }
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
            Vacancy vacancy,
            VacancyViewModel.Factory vacancyVmFactory)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            
            var db = dbContextProvider.GetDbContext();
            this.InternalVacancy = vacancy;
            this.VacancyVmFactory = vacancyVmFactory;
            db.Vacancies.Load();
            db.Disciplines.Load();
            db.Technologies.Load();
            Vacancies = db.Vacancies.Local;
            Disciplines = db.Disciplines.Local;
            Technologies = db.Technologies.Local;
        }

        #endregion

        #region Commands

        public RelayCommand archiveVacancyCommand;
        public RelayCommand ArchiveVacancyCommand
        {
            get
            {
                return archiveVacancyCommand ?? (archiveVacancyCommand = new RelayCommand(obj =>
                {
                    
                    if (InternalVacancy!=null)
                    {
                        InternalVacancy.Archived = true;
                        //logger.LogAction($"Вакансия перенесина в Архив {InternalVacancy.Id}");
                    }
                    VacancyStatusArchived();
                }));
            }
        }
        private void VacancyStatusArchived()
        {
            MessageBox.Show($"Вакансия перенесена в Архив: {InternalVacancy.Id}","Успешно",MessageBoxButton.OK, MessageBoxImage.Information);

        }
        public RelayCommand addDisciplineCommand;
        public RelayCommand AddDisciplineCommand
        {
            get
            {
                return addDisciplineCommand ?? (addDisciplineCommand = new RelayCommand(obj =>
                {
                    Discipline discipline = new Discipline();
                    dbContextProvider.GetDbContext().Disciplines.Add(discipline);
                }));
            }
        }

        public RelayCommand backVacancyCommand;
        public RelayCommand BackVacancyCommand
        {
            get
            {
                return backVacancyCommand ?? (backVacancyCommand = new RelayCommand(obj =>
                {
                    if (InternalVacancy != null)
                    {
                        InternalVacancy.Archived = false;
                        logger.LogAction($"Вакансия возобновлена: {InternalVacancy.Id}");
                    }
                    VacancyStatusBack();
                }));
            }
        }
        private void VacancyStatusBack()
        {
            MessageBox.Show($"Вакансия возобновлена: {InternalVacancy.Id}", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        public RelayCommand NResponseCommand { get; set; }

        public RelayCommand createResponseCommand;
        public RelayCommand CreateResponseCommand
        {
            get
            {
                return createResponseCommand ?? (createResponseCommand = new RelayCommand(obj =>
                {
                    Response response= new Response();
                    dbContextProvider.GetDbContext().Responses.Add(response);
                }));
            }
        }
        #endregion
    }
}
