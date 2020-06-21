using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

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

            db = dbContextProvider.GetDbContext();
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
            SelectedPerson = Persons[0];
            SelectedVacancy = Vacancies[0];            
        }
        #endregion
        JobSeekerDbContext db;
        public Response Response { get; set; }
        private Vacancy selectedVacancy;
        public Vacancy SelectedVacancy
        {
            get { return selectedVacancy; }
            set
            {
                if (selectedVacancy != value)
                {
                    selectedVacancy = value;
                    disciplines = SelectedVacancy.Disciplines.ToList();
                    foreach (Discipline discipline in disciplines)
                    {
                        if (discipline.Vacancies.Contains(SelectedVacancy))
                        {
                            foreach (Technology technology in discipline.Technologies)
                            {
                                if (!VacancyTechnologies.Contains(technology))
                                    VacancyTechnologies.Add(technology);
                            }
                        }
                    }
                }                   
            }
        }
        List<Discipline> disciplines = new List<Discipline>();

        public Person SelectedPerson { get; set; }
        public string NewAddress { get; set; }
        public string NewSocialMediaLink { get; set; }
        public Technology SelectedTechnology { get; set; }

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
                    db.Emails.Add(new Email() { Address = NewAddress, PersonId = SelectedPerson.Id });
                    DialogHost.CloseDialogCommand.Execute(null, null);
                }));
            }
        }

        private RelayCommand _addSocialMediaLinkCommand;
        public RelayCommand AddSocialMediaLinkCommand
        {
            get
            {
                return _addSocialMediaLinkCommand ?? (_addSocialMediaLinkCommand = new RelayCommand(obj =>
                {
                    db.SocialMediaLinks.Add(new SocialMediaLink() { Link = NewSocialMediaLink, PersonId = SelectedPerson.Id });
                    DialogHost.CloseDialogCommand.Execute(null, null);
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
                    SelectedPerson.Technologies.Add(SelectedTechnology);
                    DialogHost.CloseDialogCommand.Execute(null, null);
                }));
            }
        }

        private RelayCommand _hyperlink_RequestNavigateCommand;
        public RelayCommand Hyperlink_RequestNavigateCommand
        {
            get
            {
                return _hyperlink_RequestNavigateCommand ?? (_hyperlink_RequestNavigateCommand = new RelayCommand(obj =>
                {
                    string link = obj as string;
                    Process.Start(link);
                }));
            }
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(obj =>
                {
                    db.SaveChanges();
                }));
            }
        }

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(obj =>
                {
                    
                }));
            }
        }

        #endregion
    }
}
