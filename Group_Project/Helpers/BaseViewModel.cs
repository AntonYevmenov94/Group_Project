using System.ComponentModel;

namespace Group_Project
{
    /// <summary>
    /// Базовый класс для ViewModel'ей. 
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected ILogger logger;
        protected ILogMessageBuilder logMessageBuilder;
        protected IDialogService dialogService;
        protected IDbContextProvider dbContextProvider;
        public IAuthService authService;

        public BaseViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder)
        {
            this.authService = authService;
            this.dbContextProvider = dbContextProvider;
            this.dialogService = dialogService;
            this.logger = logger;
            this.logMessageBuilder = logMessageBuilder;
        }
    }
}
