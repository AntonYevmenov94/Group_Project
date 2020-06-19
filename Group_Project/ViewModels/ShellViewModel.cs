namespace Group_Project.ViewModels
{
    /// <summary>
    /// <para> Модель-представления, отвечающая за выбор и отображение страницы приложения
    /// (<see cref="Views.AuthPage"/> и <see cref="Views.MainPage"/>)</para>
    /// Привязывается напрямую к <see cref="Views.MainWindow"/>
    /// </summary>
    public class ShellViewModel : BaseViewModel
    {
        public ShellViewModel(
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
