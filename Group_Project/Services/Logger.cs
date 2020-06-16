using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group_Project;

namespace Group_Project.Services
{
    class Logger : ILogger
    {
        private readonly IAuthService accountService;
        private readonly IDbContextProvider dbContextProvider;
        
        public Logger(
            IAuthService accountService,
            IDbContextProvider dbContextProvider)
        {
            this.accountService = accountService;
            this.dbContextProvider = dbContextProvider;
        }

        public void LogAction(string logMessage, Person subject = null)
        {
            Log log = new Log() {
                Message = logMessage,
                User = accountService.LoggedUser,
                Person = subject,
                Time = DateTime.Now
            };

            dbContextProvider.GetDbContext().Log.Add(log);
            dbContextProvider.GetDbContext().SaveChanges();
        }
    }
}
