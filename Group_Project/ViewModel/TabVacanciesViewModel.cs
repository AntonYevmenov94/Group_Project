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
  public class TabVacanciesViewModel:BaseViewModel
    {
        public Vacancy Vacancy { get; set; }
        public ObservableCollection<Discipline> Disciplines { get; set; }
        public ObservableCollection<Technology> Technologies { get; set; }

        public ICommand RefreshCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand ApplyFilterCommand { get; set; }
        public ICommand ResetFilterCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand EditCommand { get; set; }



        public TabVacanciesViewModel(
            IAuthService accountService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder)
            : base(accountService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            
        }

        
    }
}
