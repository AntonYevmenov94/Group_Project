namespace Group_Project.ViewModels
{
    /// <summary>
    /// Модель-представления предназначенная для передачи и редактирования одного строкового значения.
    /// Привязывается к окну <see cref="Views.WindowTextLineEdit"/>
    /// </summary>
    public class WindowTextLineEditViewModel : BaseDialogViewModel
    {
        public string TextEdited { get; set; }
        public string HintWhatIsEdited { get; set; }

        // Фабричный метод для создания экземпляров классов, у которых не все зависимости 
        // известны на момент компиляции. Автоматически подхватывается Autofac.
        // В параметры требует только параметры конструктора, которые отсутствуют у BaseViewModel.
        // (имена параметров у фабрики и конструктора должны совпадать)
        public delegate WindowTextLineEditViewModel Factory();

        public WindowTextLineEditViewModel(
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
