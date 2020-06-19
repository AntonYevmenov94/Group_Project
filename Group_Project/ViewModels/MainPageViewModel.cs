namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления главной страницы приложения <see cref="Views.MainPage"/>.
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {
        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate MainPageViewModel Factory();

        public MainPageViewModel(
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
