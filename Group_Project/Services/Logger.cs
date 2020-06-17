using Group_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project.Services
{
    class Logger : ILogger
    {
        private IAuthService accountService;

        public Logger(IAuthService accountService)
        {
            this.accountService = accountService;
        }

        public void LogAction(string logMessage, Person subject = null)
        {
            Log log = new Log()
            {
                Message = logMessage,
                User = accountService.LoggedUser,
                Person = subject,
                Time = DateTime.Now
            };
        }
    }
}
