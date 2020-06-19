namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления вкладки на главной странице <see cref="Views.MainPage"/>,
    /// представляющей список <see cref="Person"/> и функционал CRUD операций над элементами списка.
    /// Привязывается к <see cref="Views.TabPeople"/>
    /// </summary>
    public class TabPeopleViewModel : BaseViewModel
    {
        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate TabPeopleViewModel Factory();

        public TabPeopleViewModel(
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
