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
    public class ResponseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        JobSeekerDbContext db;
        public ResponseViewModel()
        {
            db = new JobSeekerDbContext();
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
