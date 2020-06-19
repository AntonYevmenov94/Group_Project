using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления экземпляра сущности <see cref="Response"/>.
    /// Привязывается к окну <see cref="Views.WindowResponseEdit"/>
    /// </summary>
    public class ResponseViewModel : BaseDialogViewModel
    {
        #region Constructor

        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate ResponseViewModel Factory(Response response);

        public ResponseViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            Response response)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            this.Response = response;

            var db = dbContextProvider.GetDbContext();
            db.Vacancies.Load();
            db.Sex.Load();
            db.Technologies.Load();
            db.Persons.Load();
            Vacancies = new ObservableCollection<Vacancy>();
            VacancyTechnologies = new ObservableCollection<Technology>();
            Genders = new ObservableCollection<Sex>();
            Persons = new ObservableCollection<Person>();
            Vacancies = db.Vacancies.Local;
            VacancyTechnologies = db.Technologies.Local;
            Genders = db.Sex.Local;
            Persons = db.Persons.Local;
        }
        #endregion

        public Response Response { get; set; }
        public Vacancy SelectedVacansy { get; set; }
        public Person SelectedPerson { get; set; }

        public ObservableCollection<Person> Persons { get; set; }
        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Technology> VacancyTechnologies { get; set; }
        public ObservableCollection<Sex> Genders { get; set; }
        public ObservableCollection<Email> PersonEmails { get; set; }
        public ObservableCollection<SocialMediaLink> PersonSocialMediaLinks { get; set; }
        public ObservableCollection<Technology> PersonTechnologies { get; set; }

        #region Commands
        private RelayCommand _addEmailCommand;
        public RelayCommand AddEmailCommand
        {
            get
            {
                return _addEmailCommand ?? (_addEmailCommand = new RelayCommand(obj =>
                {

                }));
            }
        }

        private RelayCommand _socialMediaLinkCommand;
        public RelayCommand SocialMediaLinkCommand
        {
            get
            {
                return _socialMediaLinkCommand ?? (_socialMediaLinkCommand = new RelayCommand(obj =>
                {

                }));
            }
        }

        private RelayCommand _addTechnologyCommand;


        public RelayCommand AddTechnologyCommand
        {
            get
            {
                return _addTechnologyCommand ?? (_addTechnologyCommand = new RelayCommand(obj =>
                {

                }));
            }
        }
        #endregion


    }
}
