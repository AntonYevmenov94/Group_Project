namespace Group_Project.Services
{
    internal class AuthService : IAuthService
    {
        private User loggedUser;

        public User LoggedUser
        {
            get => loggedUser;
            set
            {
                loggedUser = value;
                AccountRights = DetermineUserGroup(loggedUser);
            }
        }

        public AccountRights AccountRights { get; private set; } = AccountRights.NonAuthenticated;


        private AccountRights DetermineUserGroup(User user)
        {
            var userRole = user?.Role;
            if (user == null || userRole == null)
            {
                return AccountRights.NonAuthenticated;
            }

            switch (userRole.Id)
            {
                case 1:
                    return AccountRights.Admin;
                case 2:
                    return AccountRights.Director;
                case 3:
                    return AccountRights.HR;
                case 4:
                    return AccountRights.MUP;
                default:
                    return AccountRights.NonAuthenticated;
            }
        }
    }
}
