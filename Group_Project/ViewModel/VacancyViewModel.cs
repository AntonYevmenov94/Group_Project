using Group_Project.Helper;
using Group_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Group_Project.ViewModel
{
    public class VacancyViewModel : BaseViewModel
    {
        #region Public properties 
        public Vacancy Vacancy { get; set; }
        public ObservableCollection<Discipline> Disciplines { get; set; }
        public ObservableCollection<Technology> Technologies{ get; set; }

        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)

        public delegate VacancyViewModel Factory(Vacancy vacancy);

        public ICommand ArchiveVacancyCommand { get; set; }
        public ICommand AddDisciplineCommand { get; set; }
        public ICommand BackVacancyCommand { get; set; }
        public ICommand NResponseCommand { get; set; }
        public ICommand CreateResponseCommand { get; set; }

        public VacancyViewModel(
            IAuthService accountService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            Vacancy vacancy)
            : base(accountService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            this.Vacancy = vacancy;
        }
        #endregion
    }
}
