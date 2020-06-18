namespace Group_Project
{
    /// <summary>
    /// Обеспечивает доступ к текущему пользователю и его роли.
    /// </summary>
    public interface IAuthService
    {
        User LoggedUser { get; set; }
        AccountRights AccountRights { get; }
    }

    public enum AccountRights
    {
        NonAuthenticated,
        Admin,
        Director,
        HR,
        MUP
    };
}
