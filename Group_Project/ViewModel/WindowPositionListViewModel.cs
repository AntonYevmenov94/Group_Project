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
    public class WindowPositionListViewModel : BaseViewModel
    {
        public ObservableCollection<Department> Departments { get; set; }
        public Department SelectedDepartment { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public WindowPositionListViewModel(IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            IAuthService accountService,
            Department department)
            : base(dbContextProvider, dialogService, logger, accountService)
        {
            
        }

    }
}
