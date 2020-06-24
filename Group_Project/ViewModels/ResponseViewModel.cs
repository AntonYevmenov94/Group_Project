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
            db.Disciplines.Load();
            Vacancies = new ObservableCollection<Vacancy>();
            Genders = new ObservableCollection<Sex>();
            Persons = new ObservableCollection<Person>();
            VacancyTechnologies = new ObservableCollection<Technology>();
            AllDisciplines = new ObservableCollection<Discipline>();
            AllDisciplines = db.Disciplines.Local;
            Vacancies = db.Vacancies.Local;
            Genders = db.Sex.Local;
            Persons = db.Persons.Local;
            Disciplines = db.Disciplines.Local;
            SelectedPerson = Persons[0];
            SelectedVacancy = Vacancies[0];
            SelectedDiscipline = Disciplines[0];
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
                    VacTechRebuild();
                }
            }
        }
        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                if (selectedPerson != value) 
                {
                    selectedPerson = value;
                    PersonEmails = new ObservableCollection<Email>(selectedPerson.Emails);
                    PersonSocialMediaLinks = new ObservableCollection<SocialMediaLink>(selectedPerson.SocialMediaLinks);
                    PersonTechnologies = new ObservableCollection<Technology>(selectedPerson.Technologies);
                }
            }
        }
        public string NewAddress { get; set; }
        public string NewSocialMediaLink { get; set; }
        public Technology SelectedTechnology { get; set; }
        public Discipline SelectedDiscipline { get; set; }

        public ObservableCollection<Person> Persons { get; set; }
        public ObservableCollection<Vacancy> Vacancies { get; set; }
        public ObservableCollection<Sex> Genders { get; set; }
        public ObservableCollection<Discipline> Disciplines { get; set; }
        public ObservableCollection<Email> PersonEmails { get; set; }
        public ObservableCollection<SocialMediaLink> PersonSocialMediaLinks { get; set; }
        public ObservableCollection<Technology> PersonTechnologies { get; set; }
        public ObservableCollection<Technology> VacancyTechnologies { get; set; }
        public ObservableCollection<Discipline> AllDisciplines { get; set; }

        #region Commands
        private RelayCommand _addEmailCommand;
        public RelayCommand AddEmailCommand
        {
            get
            {
                return _addEmailCommand ?? (_addEmailCommand = new RelayCommand(obj =>
                {
                    Email email = new Email() { Address = NewAddress, PersonId = SelectedPerson.Id };
                    db.Emails.Add(email);
                    PersonEmails.Add(email);
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
                    SocialMediaLink link = new SocialMediaLink() { Link = NewSocialMediaLink, PersonId = SelectedPerson.Id };
                    db.SocialMediaLinks.Add(link);
                    PersonSocialMediaLinks.Add(link);
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
                    if(SelectedTechnology!=null)
                    {
                        selectedPerson.Technologies.Add(SelectedTechnology);
                        PersonTechnologies.Add(SelectedTechnology);
                        DialogHost.CloseDialogCommand.Execute(null, null);
                    }
                    
                }));
            }
        }

        private RelayCommand _addDisciplineCommand;
        public RelayCommand AddDisciplineCommand
        {
            get
            {
                return _addDisciplineCommand ?? (_addDisciplineCommand = new RelayCommand(obj =>
                {
                    if (SelectedDiscipline != null)
                    {
                        Disciplines.Add(SelectedDiscipline);
                        selectedVacancy.Disciplines.Add(SelectedDiscipline);
                        VacTechRebuild();
                    }

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

        private RelayCommand _deleteLinkCommand;
        public RelayCommand DeleteLinkCommand
        {
            get
            {
                return _deleteLinkCommand ?? (_deleteLinkCommand = new RelayCommand(obj =>
                {
                    SocialMediaLink link = obj as SocialMediaLink;
                    PersonSocialMediaLinks.Remove(link);
                    db.SocialMediaLinks.Remove(link);
                }));
            }
        }

        private RelayCommand _deleteDisciplineCommand;
        public RelayCommand DeleteDisciplineCommand
        {
            get
            {
                return _deleteDisciplineCommand ?? (_deleteDisciplineCommand = new RelayCommand(obj =>
                {
                    Discipline discipline = obj as Discipline;
                    Disciplines.Remove(discipline);
                    db.Vacancies.First(v => v.Id == selectedVacancy.Id).Disciplines.Remove(discipline);
                    VacTechRebuild();
                }));
            }
        }

        private RelayCommand _deleteEmailCommand;
        public RelayCommand DeleteEmailCommand
        {
            get
            {
                return _deleteEmailCommand ?? (_deleteEmailCommand = new RelayCommand(obj =>
                {
                    Email email = obj as Email;
                    PersonEmails.Remove(email);
                    db.Emails.Remove(email);
                }));
            }
        }

        private RelayCommand _deleteTechnologyCommand;
        public RelayCommand DeleteTechnologyCommand
        {
            get
            {
                return _deleteTechnologyCommand ?? (_deleteTechnologyCommand = new RelayCommand(obj =>
                {
                    Technology technology = obj as Technology;
                    PersonTechnologies.Remove(technology);
                    selectedPerson.Technologies.Remove(technology);
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

        private void VacTechRebuild()
        {
            VacancyTechnologies = new ObservableCollection<Technology>();
            Disciplines = new ObservableCollection<Discipline>(selectedVacancy.Disciplines);
            foreach (Discipline discipline in SelectedVacancy.Disciplines)
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
