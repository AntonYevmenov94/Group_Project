using System;

namespace Group_Project.Services
{
    internal class Logger : ILogger
    {
        private readonly IAuthService authService;
        private readonly IDbContextProvider dbContextProvider;

        public Logger(
            IAuthService authService,
            IDbContextProvider dbContextProvider)
        {
            this.authService = authService;
            this.dbContextProvider = dbContextProvider;
        }

        public void LogAction(string logMessage, Person subject = null)
        {
            Log log = new Log() {
                Message = logMessage,
                User = authService.LoggedUser,
                Person = subject,
                Time = DateTime.Now
            };

            dbContextProvider.GetDbContext().Log.Add(log);
            dbContextProvider.GetDbContext().SaveChanges();
        }
    }
}
