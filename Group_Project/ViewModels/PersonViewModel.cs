namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления экземпляра сущности <see cref="Person"/>.
    /// Привязывается к окну <see cref="Views.WindowPersonEdit"/>
    /// </summary>
    public class PersonViewModel : BaseDialogViewModel
    {
        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate PersonViewModel Factory(Person person);

        public PersonViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            Person person)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
        }
    }
}
