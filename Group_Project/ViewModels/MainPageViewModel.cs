using Autofac;
using PropertyChanged;
using System;
using System.Windows.Input;

namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления главной страницы приложения <see cref="Views.MainPage"/>.
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {
        #region Public properties

        public IAppPageNavService AppPageNavService { get; set; }

        // касающиеся вкладок
        public bool IsTabVacanciesActive { get; set; } = true;
        public bool IsTabResponsesActive { get; set; }
        public bool IsTabEmployeesActive { get; set; }
        public bool IsTabPeopleActive { get; set; }
        [DependsOn(
            nameof(IsTabVacanciesActive), nameof(IsTabResponsesActive),
            nameof(IsTabEmployeesActive), nameof(IsTabPeopleActive))]
        public BaseViewModel ActiveTabViewModel
        {
            get
            {
                if (IsTabVacanciesActive)
                {
                    var vm = Services.IoCContainerProvider.Container.Resolve<TabVacanciesViewModel>();
                    return vm;
                }
                else if (IsTabResponsesActive)
                {
                    var vm = Services.IoCContainerProvider.Container.Resolve<TabResponsesViewModel>();
                    return vm;
                }
                else if (IsTabEmployeesActive)
                {
                    var vm = Services.IoCContainerProvider.Container.Resolve<TabPeopleViewModel>();
                    return vm;
                }
                else if (IsTabPeopleActive)
                {
                    var vm = Services.IoCContainerProvider.Container.Resolve<TabPeopleViewModel>();
                    return vm;
                }
                else
                    return null;
            }
        }

        // команды
        #region Commands

        public ICommand CmdLogout { get; set; }
        #endregion
        #endregion


        #region Constructor

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
            ILogMessageBuilder logMessageBuilder,
            IAppPageNavService appPageNavService)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
            AppPageNavService = appPageNavService;

            CmdLogout = new RelayCommand(new Action<object>(Logout));
        }
        #endregion


        #region Command implementation

        private void Logout(object obj)
        {
            AppPageNavService.ActiveAppPage = AppPage.AuthPage;
            // TODO логика
        }
        #endregion
    }
}
