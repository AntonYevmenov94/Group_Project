using System;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления главной страницы приложения <see cref="Views.AuthPage"/>.
    /// </summary>
    public class AuthPageViewModel : BaseViewModel
    {
        public IAppPageNavService AppPageNavService { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsTryingToLogin { get; set; }
        public string ConnectionErrorMessage { get; set; }
        public bool HasConnectionError { get; set; }

        public ICommand CmdLogin { get; set; }


        #region Constructor

        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate AuthPageViewModel Factory();

        public AuthPageViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            IAppPageNavService appPageNavService)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            AppPageNavService = appPageNavService;

            CmdLogin = new RelayCommand(new Action<object>(Login));
        }
        #endregion


        private void Login(object obj)
        {
            IsTryingToLogin = true;
            
            // TODO сделать логику залогивания
            AppPageNavService.ActiveAppPage = AppPage.MainPage;



            IsTryingToLogin = false;
        }

    }
}
