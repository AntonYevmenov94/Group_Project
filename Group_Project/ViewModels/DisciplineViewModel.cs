namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления экземпляра сущности <see cref="Discipline"/>.
    /// Привязывается к окну <see cref="Views.WindowDisciplineEdit"/>
    /// </summary>
    public class DisciplineViewModel : BaseDialogViewModel
    {
        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate DisciplineViewModel Factory(Discipline discipline);


        public DisciplineViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            Discipline discipline)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
        }
    }
}
