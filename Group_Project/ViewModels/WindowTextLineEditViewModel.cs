namespace Group_Project.ViewModels
{
    public class WindowTextLineEditViewModel : BaseDialogViewModel
    {
        public string TextEdited { get; set; }
        public string HintWhatIsEdited { get; set; }

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
