namespace Group_Project.ViewModels
{
    public class TabEmployeesViewModel : BaseViewModel
    {
        public TabEmployeesViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
        }
    }
}
