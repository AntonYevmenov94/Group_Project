namespace Group_Project
{
    /// <summary>
    /// Сервис для обеспечения возможности смены страниц приложения из 
    /// моделей представлений отличных от <see cref="ViewModels.ShellViewModel"/>
    /// </summary>
    public interface IAppPageNavService
    {
        AppPage ActiveAppPage { get; set; }
        BaseViewModel ActivePageViewModel { get; }
    }
}