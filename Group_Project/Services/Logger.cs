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
        private IAccountService accountService;
        
        public Logger(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public void LogAction(string logMessage, Person subject = null)
        {
            Group_Project.Log log;
        }
    }
}
