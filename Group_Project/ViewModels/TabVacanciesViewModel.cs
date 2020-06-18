using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    public class TabVacanciesViewModel : BaseViewModel
    {
        public Vacancy SelectedVacancy { get; set; }
        public ObservableCollection<Discipline> Disciplines { get; set; }
        public ObservableCollection<Technology> Technologies { get; set; }

        public ICommand RefreshCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand ApplyFilterCommand { get; set; }
        public ICommand ResetFilterCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand CloseComman { get; set; }
        public ICommand EditComman { get; set; }



        public TabVacanciesViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            Vacancy vacancy)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            this.SelectedVacancy = vacancy;
        }
    }
}
