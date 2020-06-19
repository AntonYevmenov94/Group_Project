namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления экземпляра сущности <see cref="Discipline"/>.
    /// Привязывается к окну <see cref=""/>
    /// </summary>
    public class EmployeeViewModel : BaseDialogViewModel
    {
        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate EmployeeViewModel Factory(Employee employee);


        public EmployeeViewModel(
            IAuthService authService,
            IDbContextProvider dbContextProvider,
            IDialogService dialogService,
            ILogger logger,
            ILogMessageBuilder logMessageBuilder,
            Employee employee)
            : base(authService, dbContextProvider, dialogService, logger, logMessageBuilder)
        {
        }
    }
}
